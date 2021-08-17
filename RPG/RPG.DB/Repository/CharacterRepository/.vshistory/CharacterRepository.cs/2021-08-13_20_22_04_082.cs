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
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
        }

        public async Task<List<GetCharacterDto>> DeleteCharacters(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<GetCharacterDto>> GetAllCharacters()
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetCharacterDto> GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            throw new System.NotImplementedException();
        }
    }
}
