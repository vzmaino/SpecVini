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
        public static List<Models.ClienteViewModel> dataBaseClientes = new List<Models.ClienteViewModel>
        {
            new Models.ClienteViewModel
            {
                Nome = "Vinicius",
                Id = 1,
                CPF = "123456789-01",
                DataDeNascimento = new DateTime(1993,10,16),
                GastosEmCompras = 0
            }
        };

        [HttpGet]
        public List<Models.ClienteViewModel> GetAll()
        {
            return dataBaseClientes;
        }

        [HttpGet("{id}")]
        public ClienteViewModel Get(int id)
        {
            var clienteSelecionado = new ClienteViewModel();
            foreach (var cliente in dataBaseClientes)
            {
                if (id == cliente.Id)
                {
                    clienteSelecionado = new ClienteViewModel();
                    clienteSelecionado.Nome = cliente.Nome;
                    clienteSelecionado.Compras = cliente.GastosEmCompras;
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
        public void Post([FromBody] Models.ClienteViewModel newcliente)
        {
            dataBaseClientes.Add(newcliente);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.ClienteViewModel newCliente)
        {
            foreach (var cliente in dataBaseClientes)
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
            foreach(var cliente in dataBaseClientes)
            {
                if (id == cliente.Id)
                {
                    
                }
            }
        }

        [HttpGet("{id}")]
        public IEnumerable<ClienteViewModel> ListarClienteEspecifico(int id)
        {
            var clienteSelecionado = from cliente in dataBaseClientes
                                     where cliente.Id == id
                                     select new ClienteViewModel
                                     {
                                         Nome = cliente.Nome,
                                         Compras = cliente.GastosEmCompras
                                     };

            return clienteSelecionado;

        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> ListarTopClientes()
        {
            var clienteSelecionado = from cliente in dataBaseClientes
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