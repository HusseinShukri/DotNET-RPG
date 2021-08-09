using Microsoft.EntityFrameworkCore;

namespace RPG.Data.Contect
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Character>{get;set;}
        
    }
}
