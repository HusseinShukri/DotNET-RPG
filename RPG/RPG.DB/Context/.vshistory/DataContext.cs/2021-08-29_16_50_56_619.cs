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
        public DbSet<Skill> Skill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluintApi
            modelBuilder.Entity<User>()
              .HasMany(fKey => fKey.Character)
              .WithOne(pKey => pKey.User)
              .HasForeignKey(key => key.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasOne(fkey => fkey.User)
                .WithMany(pkey => pkey.Character)
                .HasForeignKey(key => key.UserId);

            modelBuilder.Entity<Weapon>()
                .HasOne(fkey => fkey.Character)
                .WithOne(pkey => pkey.Weapon)
                .HasForeignKey<Weapon>(key => key.CharacterId);

            modelBuilder.Entity<Character>()
                .HasOne(fkey => fkey.Weapon)
                .WithOne(pkey => pkey.Character)
                .HasForeignKey<Character>(key => key.WeaponId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
