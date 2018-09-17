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
            var clientesCadastrados = _context
               .Clientes
               .Where(c => c.Deletado != true)
               .ToList();

            return clientesCadastrados;
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
            var putCliente = _context
                .Clientes
                .FirstOrDefault(c => c.Id == id);

            putCliente.Id = newCliente.Id;
            putCliente.Nome = newCliente.Nome;
            putCliente.CPF = newCliente.CPF;
            putCliente.DataDeNascimento = newCliente.DataDeNascimento;
            putCliente.GastosEmCompras = newCliente.GastosEmCompras;
            putCliente.Deletado = newCliente.Deletado;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var clienteDeletado = _context
                .Clientes
                .Single(c => c.Id == id);

            clienteDeletado.Deletado = true;
            _context.SaveChanges();
        }

        [HttpGet("especifico/{id}")]
        public IEnumerable<ClienteViewModel> ListarClienteEspecifico(int id)
        {
            var clienteSelecionado = _context
                .Clientes
                .Where(c => c.Id == id)
                .Select(c => new ClienteViewModel
                {
                    Nome = c.Nome,
                    Compras = c.GastosEmCompras
                });

            return clienteSelecionado;
        }

        [HttpGet("top")]
        public IEnumerable<ClienteViewModel> ListarTopClientes()
        {
            var clienteSelecionado = _context
                .Clientes
                .OrderByDescending(c => c.GastosEmCompras)
                .Select(c => new ClienteViewModel
                {
                    Nome = c.Nome,
                    Compras = c.GastosEmCompras
                })
                .Take(10);

            return clienteSelecionado;
        }
    }
}