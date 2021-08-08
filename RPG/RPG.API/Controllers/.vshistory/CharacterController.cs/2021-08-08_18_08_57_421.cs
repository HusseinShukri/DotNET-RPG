using Microsoft.AspNetCore.Mvc;
using RPG.API.Models;
using RPG.Data.Models;
using RPG.Services.CharacterServices;
using System.Collections.Generic;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Route("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_characterService.GetAllCharacters());
        }

        [Route("[action]/{id}")]
        public IActionResult GetSingle( int id=0)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult AddCharacter([FromBody] Character character) {
            return Ok(_characterService.AddCharacter(character));
        }

    }
}
