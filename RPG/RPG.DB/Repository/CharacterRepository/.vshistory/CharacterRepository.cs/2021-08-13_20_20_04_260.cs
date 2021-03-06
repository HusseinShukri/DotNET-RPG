using AutoMapper;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
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

        public Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GetCharacterDto>> DeleteCharacters(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<GetCharacterDto>> GetAllCharacters()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetCharacterDto> GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            throw new System.NotImplementedException();
        }
    }
}
