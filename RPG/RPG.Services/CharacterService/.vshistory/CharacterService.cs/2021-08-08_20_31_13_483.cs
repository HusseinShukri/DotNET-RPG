using RPG.Data.Models;
using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> CharacterList = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(Character newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<Character>>();
            CharacterList.Add(newCharacter);
            serviceResponse.Data = CharacterList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = CharacterList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = CharacterList.Find(c => c.Id == id);
            return serviceResponse;
        }
    }
}
