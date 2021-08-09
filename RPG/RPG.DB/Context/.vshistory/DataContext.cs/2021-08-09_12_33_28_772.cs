using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;
using RPG.Data.Seeds;

namespace RPG.Data.Contect
{
    public class DataContext : DbContext
    {
        protected DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
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
