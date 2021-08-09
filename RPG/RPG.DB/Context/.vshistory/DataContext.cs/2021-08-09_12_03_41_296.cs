using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data.Contect
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                b.Ignore(c => c.AccessFailedCount)
                .Ignore(c => c.EmailConfirmed)
                .Ignore(c => c.PhoneNumber)
                .Ignore(c => c.PhoneNumberConfirmed)
                .Ignore(c => c.TwoFactorEnabled)
                .Ignore(c => c.LockoutEnabled)
                .Ignore(c => c.LockoutEnd)
                .Ignore(c => c.AccessFailedCount);
            });


            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

    }
}
