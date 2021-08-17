using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public class CharacterReository : ICharacterReository
    {
        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            throw new System.NotImplementedException();
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
