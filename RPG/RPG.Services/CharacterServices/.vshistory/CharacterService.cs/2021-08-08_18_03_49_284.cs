﻿using RPG.Data.Models;
using System.Collections.Generic;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        public List<Character> AddCharacter(Character newCharacter)
        {
            CharacterList.Add(character);
            return CharacterList;
        }

        public List<Character> GetAllCharacters()
        {
            return CharacterList;
        }

        public Character GetCharacterById(int id)
        {
            var result = CharacterList.Find(c => c.Id == id);
            return result;
        }
    }
}
