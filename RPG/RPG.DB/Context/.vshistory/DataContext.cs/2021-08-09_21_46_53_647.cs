using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data.Context
{
    public class DataContext : DbContext
    {
        protected DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Character> Character { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasOne(e => e.User)
               .WithMany(u => u.Employee).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}   
