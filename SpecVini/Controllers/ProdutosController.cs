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
    public class ProdutoController : ControllerBase
    {
        private readonly SpecContexto _context;

        public ProdutoController(SpecContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        //[HttpGet("{id}")]
        //public Produto Get(int id)
        //{
        //    foreach (var produto in _context.Produtos)
        //    {
        //        if (id == produto.Id)
        //        {
        //            return produto;
        //        }
        //    }
        //    return null;
        //}

        [HttpPost]
        public void Post([FromBody] Produto newproduto)
        {
            _context.Produtos.Add(newproduto);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto newProduto)
        {
            foreach (var produto in _context.Produtos)
            {
                if (id != produto.Id)
                {
                    produto.Id = newProduto.Id;
                    produto.SKU = newProduto.SKU;
                    produto.Descricao = newProduto.Descricao;
                    produto.Dimensoes = newProduto.Dimensoes;
                    produto.Quantidade = newProduto.Quantidade;
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (var produto in _context.Produtos)
            {
                var deletar = produto;
                if (id == produto.Id)
                {
                    deletar = null;
                    _context.SaveChanges();
                }
            }
        }

        [HttpGet("[controller]/{id}")]
        public IEnumerable<Produto> ListarEstoqueEspecifico(int id)
        {
            var estoqueEspecifico = from produto in _context.Produtos
                                    where produto.Id == id
                                    select produto;

            return estoqueEspecifico;
        }
    }
}