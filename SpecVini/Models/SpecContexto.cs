using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpecVini.Models;

namespace SpecVini.Models
{
    public class SpecContexto : DbContext
    {
        public SpecContexto(DbContextOptions<SpecContexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}

