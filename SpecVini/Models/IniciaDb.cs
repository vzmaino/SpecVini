using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecVini.Models
{
    public static class IniciaDb
    {
        public static void Initialize(SpecContexto context)
        {
            context.Database.EnsureCreated();

            if (context.Clientes.Any())
            {
                return;
            }

            if (context.Produtos.Any())
            {
                return;
            }


            var cliente = new Cliente
            {
                Nome = "Vinicius",
                Id = 1,
                CPF = "123456789-01",
                DataDeNascimento = new DateTime(1993,10,16),
                GastosEmCompras = 0
            };

            var produto = new Produto
            {
                Id = 1,
                SKU = 1,
                Descricao = "Salame", 
                Dimensoes  = "50x10x5",
                Quantidade = 2
            };

            context.Clientes.Add(cliente);
            context.Produtos.Add(produto);
            context.SaveChanges();
        }
    }
}
