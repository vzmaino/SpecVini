using SpecVini.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecVini.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int SKU { get; set; }
        public string Descricao { get; set; }
        public string Dimensoes { get; set; }
        public int Quantidade { get; set; }
       
    }
}
