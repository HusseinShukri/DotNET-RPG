using Microsoft.AspNetCore.Mvc;
using RPG.API.Models;
using RPG.Services.CharacterServices;
using System.Collections.Generic;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> CharacterList = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Route("[action]")]
        public IActionResult GetAll()
        {
            return Ok(CharacterList);
        }

        [Route("[action]/{id}")]
        public IActionResult GetSingle( int id=0)
        {
            var result = CharacterList.Find(c => c.Id == id);
            return Ok(result);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddCharacter([FromBody] Character character) {
            CharacterList.Add(character);
            return Ok(CharacterList);
        }

    }
}
