using RPG.Domain.DTO.Skill;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Entities;
using System.Collections.Generic;

namespace RPG.Domain.Dto.Character
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ammar";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skills { get; set; }
    }
}
