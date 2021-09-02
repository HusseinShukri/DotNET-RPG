using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPG.Domain.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "Ammar";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }

        public Weapon Weapon { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
