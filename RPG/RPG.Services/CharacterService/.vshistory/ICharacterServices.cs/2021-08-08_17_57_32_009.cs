using RPG.Data.Models;
using System.Collections.Generic;

namespace RPG.Services.CharacterServices
{
    public interface ICharacterServices
    {
        public List<Character> GetAllCharacters();

    }
}
