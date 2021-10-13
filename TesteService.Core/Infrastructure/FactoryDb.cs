using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Infrastructure.Context;

namespace TesteService.Core.Infrastructure
{
    public class FactoryDb : IDesignTimeDbContextFactory<TesteDb>
    {
        public TesteDb CreateDbContext(string[] args)
        {
            string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=bancoprado;Trusted_Connection=True;MultipleActiveResultSets=true";
            //string ConnectionString = "Data Source=DESKTOP-SJ4OGNO;Initial Catalog=Teste;Integrated Security=True;";
            DbContextOptionsBuilder<TesteDb> optionsBuilder = new DbContextOptionsBuilder<TesteDb>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new TesteDb(optionsBuilder.Options);
        }
    }
}
