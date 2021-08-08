using RPG.Data.Models;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<ServiceResponse<Character>> CharacterList = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            CharacterList.Add(newCharacter);
            return CharacterList;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            return CharacterList;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            return CharacterList.Find(c => c.Id == id);
        }
    }
}
