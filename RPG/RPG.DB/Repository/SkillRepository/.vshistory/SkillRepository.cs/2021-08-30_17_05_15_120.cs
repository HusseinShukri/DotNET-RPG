using AutoMapper;
using RPG.Data.Context;
using RPG.Domain.DTO.Skill;
using RPG.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.SkillRepository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SkillRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<GetSkillDto>> AddSkill(NewSkillDto newSkill)
        {
            var skill = _mapper.Map<Skill>(newSkill);
            _dataContext.Skill.Add(skill);
            await SaveChanges();
        }

        public async Task<List<GetSkillDto>> DeleteSkill(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<GetSkillDto>> GetAllSkills()
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetSkillDto> GetSkillById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<GetSkillDto> UpdateSkill(UpdateSkillDto updateSkill)
        {
            throw new System.NotImplementedException();
        }
    }
}
