using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceQuotes.Common
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Price> Prices { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=JIMS;database=myDatabase;trusted_connection=true;");
        }
    }
}
