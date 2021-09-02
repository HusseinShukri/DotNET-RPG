using System.ComponentModel.DataAnnotations.Schema;

namespace RPG.Domain.Entities
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }

        [ForeignKey(nameof(CharacterId))]
        public Character Character { get; set; }
    }
}
