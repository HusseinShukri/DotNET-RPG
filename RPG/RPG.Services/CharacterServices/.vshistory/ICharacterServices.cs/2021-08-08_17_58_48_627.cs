using RPG.Data.Models;
using System.Collections.Generic;

namespace RPG.Services.CharacterServices
{
    public interface ICharacterServices
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);

    }
}
