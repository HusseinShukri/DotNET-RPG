using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data.Contect
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Character> Characters{get; set;}
        
    }
}
