using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;
using RPG.Data.Seeds;

namespace RPG.Data.Contect
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected DataContext()
        {
        }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

    }
}
