using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Character> character { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}   
