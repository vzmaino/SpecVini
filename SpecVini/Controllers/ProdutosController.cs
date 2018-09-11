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
        public static List<Produto> dataBaseProdutos = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                SKU = 1,
                Descricao = "Salame",
                Dimensoes = "15x5x5",
                Quantidade = 0
            }
        };

        [HttpGet]
        public List<Produto> GetAll()
        {
            return dataBaseProdutos;
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            foreach (var produto in dataBaseProdutos)
            {
                if (id == produto.Id)
                {
                    return produto;
                }
            }
            return null;
        }

        [HttpPost]
        public void Post([FromBody] Produto newproduto)
        {
            dataBaseProdutos.Add(newproduto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produto newProduto)
        {
            foreach (var produto in dataBaseProdutos)
            {
                if (id == produto.Id)
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
            foreach (var produto in dataBaseProdutos)
            {
                var deletar = produto;
                if (id == produto.Id)
                {
                    deletar = null;
                }
            }
        }


        //public void ListarEstoque()
        //{
            
        //}

        [HttpGet("[controller]/{ id:int}")]
        public IEnumerable<Produto> ListarEstoqueEspecifico(int id)
        {
            var estoqueEspecifico = from produto in dataBaseProdutos
                                    where produto.Id == id
                                    select produto;

            return estoqueEspecifico;
        }
    }
}