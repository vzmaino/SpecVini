using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SpecVini.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<SpecContexto>
{
    public SpecContexto CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var builder = new DbContextOptionsBuilder<SpecContexto>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseMySql(connectionString);

        return new SpecContexto(builder.Options);
    }
}
