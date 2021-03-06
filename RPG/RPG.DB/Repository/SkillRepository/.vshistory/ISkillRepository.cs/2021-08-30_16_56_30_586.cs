using RPG.Domain.DTO.Skill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.SkillRepository
{
    public interface ISkillRepository
    {
        Task<List<GetSkillDto>> GetAllSkills(int userId);
        Task<GetSkillDto> GetCharacterById(int id, int userId);
        Task<List<GetSkillDto>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<GetSkillDto> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId);
        Task<List<GetSkillDto>> DeleteCharacters(int id, int userId);
        Task<bool> SaveChanges();
    }
}
