using AutoMapper;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
using RPG.Domain.Models;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public class CharacterReository : ICharacterReository
    {
        private readonly IMapper _mapper;
        private readonly DataContext dataContext;

        public CharacterReository(IMapper mapper, DataContext dataContext)
        {
            this._mapper = mapper;
            this.dataContext = dataContext;
        }

        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            await _dataContext.Character.AddAsync(character);
            await _dataContext.SaveChangesAsync();
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(_dataContext.Character.ToList());
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            throw new System.NotImplementedException();
        }
    }
}
