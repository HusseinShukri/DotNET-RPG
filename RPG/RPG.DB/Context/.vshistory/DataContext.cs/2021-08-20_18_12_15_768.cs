using Microsoft.EntityFrameworkCore;
using RPG.Domain.Entities;

namespace RPG.Data.Context
{
    public class DataContext : DbContext
    {
        protected DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Character> Character { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Weapon> Weapon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluintApi
            modelBuilder.Entity<User>()
            .HasMany(fKey => fKey.Characters)
            .WithOne(pKey => pKey.User)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Weapon>()
                .HasOne(fkey => fkey.Character)
                .WithOne(pkey => pkey.Weapon);

            base.OnModelCreating(modelBuilder);
        }
    }
}
