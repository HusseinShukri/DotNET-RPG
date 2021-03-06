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


        public DbSet<Character> Character { get; set; }
        public DbSet<RpgClass> rpgClasse { get; set; }

    }
}
