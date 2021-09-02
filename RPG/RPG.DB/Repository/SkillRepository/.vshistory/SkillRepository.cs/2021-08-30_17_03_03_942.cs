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

        public Task<List<GetSkillDto>> AddSkill(NewSkillDto newSkill)
        {
            _dataContext.Skill.Add(_mapper.Map<Skill>(newSkill))
        }

        public Task<List<GetSkillDto>> DeleteSkill(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GetSkillDto>> GetAllSkills()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetSkillDto> GetSkillById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetSkillDto> UpdateSkill(UpdateSkillDto updateSkill)
        {
            throw new System.NotImplementedException();
        }
    }
}
