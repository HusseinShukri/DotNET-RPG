using Microsoft.AspNetCore.Mvc;
using RPG.Domain.Dto.Character;
using RPG.Services.CharacterServices;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> GetSingle(int id = 0)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCharacter([FromBody] AddCharacterDto character) {
            return Ok(await _characterService.AddCharacter(character));
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody]UpdateCharacterDto updateCharacter) {
            var serviceResponse =  await _characterService.UpdateCharacter(updateCharacter);
            if (!serviceResponse.Success) {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [Route("[action/{id}]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCharacter() {
            var serviceResponse = await _characterService.DeleteCharacters(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

    }
}
