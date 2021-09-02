using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
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
        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter, int userId)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            character.UserId = userId;
            await _dataContext.Character.AddAsync(character);
            await SaveChanges();
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.Where(c => c.User.Id == userId).ToListAsync());
        }

        public async Task<List<GetCharacterDto>> DeleteCharacters(int id, int userId)
        {
            var character = await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            if (character == null) { return null; }
            _dataContext.Character.Remove(character);
            await SaveChanges();
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<List<GetCharacterDto>> GetAllCharacters(int userId)
        {
            var a = await _dataContext.Character.Include(c => c.Weapon).Where(c => c.User.Id == userId).ToListAsync();
            return _mapper.Map<List<GetCharacterDto>>(a);
        }

        public async Task<GetCharacterDto> GetCharacterById(int id, int userId)
        {
            return _mapper.Map<GetCharacterDto>(await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId));
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId)
        {
            if (await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id && c.UserId == userId) == null)
            {
                return null;
            }
            var character = _mapper.Map<Character>(updateCharacter);
            _dataContext.Character.Update(character);
            if (await SaveChanges())
            {
                return _mapper.Map<GetCharacterDto>(character);
            }
            return null;
        }
    }
}
