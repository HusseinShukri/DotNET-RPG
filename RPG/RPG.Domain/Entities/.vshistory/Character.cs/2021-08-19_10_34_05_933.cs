using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPG.Domain.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "حسين";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

        [ForeignKey(nameof(User))]
        public int userId { get; set; }
        public User User { get; set; }
    }
}
