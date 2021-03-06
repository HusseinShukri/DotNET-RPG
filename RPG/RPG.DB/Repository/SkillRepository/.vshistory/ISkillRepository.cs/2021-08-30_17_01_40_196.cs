using RPG.Domain.DTO.Skill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.SkillRepository
{
    public interface ISkillRepository
    {
        Task<List<GetSkillDto>> GetAllSkills();
        Task<GetSkillDto> GetCharacterById(int id);
        Task<List<GetSkillDto>> AddSkill(NewSkillDto newSkill);
        Task<GetSkillDto> UpdateSkill(UpdateSkillDto updateSkill);
        Task<List<GetSkillDto>> DeleteSkill(int id);
        Task<bool> SaveChanges();
    }
}
