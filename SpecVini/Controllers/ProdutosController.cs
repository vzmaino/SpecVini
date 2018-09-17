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

        [HttpPost]
        public void Post([FromBody] Produto newproduto)
        {
            _context.Produtos.Add(newproduto);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto newProduto)
        {
            var putProduto = _context
                .Produtos
                .FirstOrDefault(p => p.Id == id);
                
            putProduto.Id = newProduto.Id;
            putProduto.SKU = newProduto.SKU;
            putProduto.Descricao = newProduto.Descricao;
            putProduto.Dimensoes = newProduto.Dimensoes;
            putProduto.Quantidade = newProduto.Quantidade;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var produtoDeletado = _context
                .Produtos
                .Select(p => p.Id == id);

            _context.Remove(produtoDeletado);
            _context.SaveChanges();
        }

        [HttpGet("[controller]/{id}")]
        public Produto ListarEstoqueEspecifico(int id)
        {
            var estoqueEspecifico = _context
                .Produtos
                .FirstOrDefault(p => p.Id == id);

            return estoqueEspecifico;
        }
    }
}