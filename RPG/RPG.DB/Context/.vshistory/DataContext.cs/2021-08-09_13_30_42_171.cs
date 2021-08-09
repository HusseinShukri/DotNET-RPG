using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Character> character { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}   
