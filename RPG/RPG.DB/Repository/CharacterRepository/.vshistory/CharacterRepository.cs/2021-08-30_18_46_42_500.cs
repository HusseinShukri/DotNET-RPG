using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Skill;
using RPG.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        //change it later
        //check if user exist
        public async Task<List<CharacterDto>> AddCharacter(AddCharacterDto newCharacter, int userId)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            character.UserId = userId;
            await _dataContext.Character.AddAsync(character);
            await SaveChanges();
            return _mapper.Map<List<CharacterDto>>(await _dataContext.Character.Where(c => c.User.Id == userId).ToListAsync());
        }

        public async Task<List<CharacterDto>> DeleteCharacters(int id, int userId)
        {
            var character = await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (character == null) { return null; }
            _dataContext.Character.Remove(character);
            await SaveChanges();
            return _mapper.Map<List<CharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<List<CharacterDto>> GetAllCharacters(int userId)
        {
            var a = await _dataContext.Character.Include(c => c.Skills)
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .Where(c => c.User.Id == userId)
                .ToListAsync();
            return _mapper.Map<List<CharacterDto>>(a);
        }

        public async Task<CharacterDto> GetCharacterById(int id, int userId)
        {
            return _mapper.Map<CharacterDto>(await _dataContext.Character
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId));
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<CharacterDto> UpdateCharacter(CharacterDto updateCharacter, int userId)
        {
            if (await GetCharacterById(updateCharacter.Id, userId) == null)
            {
                return null;
            }
            var character = _mapper.Map<Character>(updateCharacter);
            _dataContext.Character.Update(character);
            if (await SaveChanges())
            {
                return _mapper.Map<CharacterDto>(character);
            }
            return null;
        }

        public async Task<CharacterDto> AddCharacterSkill(AddCharacterSkill newCharacterSkill)
        {
            var character = await _dataContext.Character
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.UserId == userId));
            ServiceResponse<CharacterDto> response = new();
            if (character == null)
            {
                response.Success = false;
                response.Message = "character not found";
                return response;
            }

            var skill = await _skillRepository.GetSkillById(newCharacterSkill.SkillId);

            if (skill == null)
            {
                response.Success = false;
                response.Message = "skill not found";
                return response;
            }
            character = await _characterRepository.AddCharacterSkill(character, newCharacterSkill.SkillId);
            if (character == null)
            {
                response.Success = false;
                response.Message = "Error";
                return response;
            }
            response.Data = character;
            response.Message = "Skill " + skill.Name + " was added into character " + character.Name;
            return response;
        }

    }
}
