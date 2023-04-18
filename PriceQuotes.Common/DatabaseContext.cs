using Microsoft.EntityFrameworkCore;

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
