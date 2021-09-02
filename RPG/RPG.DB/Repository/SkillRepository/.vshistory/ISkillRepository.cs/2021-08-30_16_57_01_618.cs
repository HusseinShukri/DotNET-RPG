using RPG.Domain.DTO.Skill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.SkillRepository
{
    public interface ISkillRepository
    {
        Task<List<GetSkillDto>> GetAllSkills();
        Task<GetSkillDto> GetCharacterById(int id);
        Task<List<GetSkillDto>> AddSkill(AddCharacterDto newCharacter, int userId);
        Task<GetSkillDto> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId);
        Task<List<GetSkillDto>> DeleteCharacters(int id, int userId);
        Task<bool> SaveChanges();
    }
}
