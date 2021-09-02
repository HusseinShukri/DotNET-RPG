using RPG.Data.Context;
using RPG.Domain.DTO.Skill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.SkillRepository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _dataContext;

        public SkillRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<GetSkillDto>> AddSkill(NewSkillDto newSkill)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GetSkillDto>> DeleteCharacters(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GetSkillDto>> GetAllSkills()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetSkillDto> GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetSkillDto> UpdateCharacter(UpdateSkillDto updateSkill)
        {
            throw new System.NotImplementedException();
        }
    }
}
