using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
using RPG.Domain.Entities;
using System.Collections.Generic;
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

        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            await _dataContext.Character.AddAsync(character);
            await SaveChanges();
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<List<GetCharacterDto>> DeleteCharacters(int id)
        {
            var character = await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id);
            if (character == null) { return null; }
            _dataContext.Character.Remove(character);
            await SaveChanges();
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<List<GetCharacterDto>> GetAllCharacters()
        {
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<GetCharacterDto> GetCharacterById(int id)
        {
            return _mapper.Map<GetCharacterDto>(await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<bool> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var character = _mapper.Map<Character>(updateCharacter);
            _dataContext.Character.Update(character);
            var success = await SaveChanges();
            if (success)
            {
                return _mapper.Map<GetCharacterDto>(character);
            }
            return null;
        }
    }
}
