using RPG.Domain.DTO.Weapon;
using RPG.Domain.Entities;

namespace RPG.Domain.Dto.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ammar";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
    }
}
