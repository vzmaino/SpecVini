using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecVini.Models
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public int GastosEmCompras { get; set; }
    }
}
