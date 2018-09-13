using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecVini.Models;

namespace SpecVini.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly SpecContexto _context;

        public ClientesController(SpecContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var clienteSelecionado = new Cliente();
            foreach (var cliente in _context.Clientes)
            {
                if (id == cliente.Id)
                {
                    clienteSelecionado = new Cliente();
                    clienteSelecionado.Nome = cliente.Nome;
                    clienteSelecionado.GastosEmCompras = cliente.GastosEmCompras;
                } 
            }
            if(clienteSelecionado != null)
            {
                return clienteSelecionado;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public void Post([FromBody] Cliente newcliente)
        {
            _context.Clientes.Add(newcliente);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente newCliente)
        {
            foreach (var cliente in _context.Clientes)
            {
                if (id == cliente.Id)
                {
                    cliente.Nome = newCliente.Nome;
                    cliente.Id = newCliente.Id;
                    cliente.CPF = newCliente.CPF;
                    cliente.DataDeNascimento = newCliente.DataDeNascimento;
                    cliente.GastosEmCompras = newCliente.GastosEmCompras;
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach(var cliente in _context.Clientes)
            {
                if (id == cliente.Id)
                {
                    
                }
            }
        }

        [HttpGet("especifico/{id}")]
        public IEnumerable<ClienteViewModel> ListarClienteEspecifico(int id)
        {
            var clienteSelecionado = from cliente in _context.Clientes
                                     where cliente.Id == id
                                     select new ClienteViewModel
                                     {
                                         Nome = cliente.Nome,
                                         Compras = cliente.GastosEmCompras
                                     };

            return clienteSelecionado;

        }

        [HttpGet("top")]
        public IEnumerable<ClienteViewModel> ListarTopClientes()
        {
            var clienteSelecionado = from cliente in _context.Clientes
                                     orderby cliente.GastosEmCompras
                                     select new ClienteViewModel
                                     {
                                         Nome = cliente.Nome,
                                         Compras = cliente.GastosEmCompras
                                     };

            clienteSelecionado.Take(10);
            return clienteSelecionado;
        }
    }
}