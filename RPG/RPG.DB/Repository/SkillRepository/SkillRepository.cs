using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            return _mapper.Map<List<GetSkillDto>>(await _dataContext.Skill.ToListAsync());
        }

        public async Task<List<GetSkillDto>> DeleteSkill(int id)
        {
            var skill = await _dataContext.Skill.FirstOrDefaultAsync(c => c.Id == id);
            if (skill == null) { return null; }
            _dataContext.Skill.Remove(skill);
            await SaveChanges();
            return _mapper.Map<List<GetSkillDto>>(await _dataContext.Skill.ToListAsync());
        }

        public async Task<List<GetSkillDto>> GetAllSkills()
        {
            return _mapper.Map<List<GetSkillDto>>(await _dataContext.Skill.ToArrayAsync());
        }

        public async Task<GetSkillDto> GetSkillById(int id)
        {
            return _mapper.Map<GetSkillDto>(await _dataContext.Skill.FirstOrDefaultAsync(s => s.Id == id));
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<GetSkillDto> UpdateSkill(UpdateSkillDto updateSkill)
        {
            if (await GetSkillById(updateSkill.Id) == null)
            {
                return null;
            }
            var skill = _mapper.Map<Skill>(updateSkill);
            _dataContext.Skill.Update(skill);
            if (await SaveChanges())
            {
                return _mapper.Map<GetSkillDto>(skill);
            }
            return null;
        }
    }
}
