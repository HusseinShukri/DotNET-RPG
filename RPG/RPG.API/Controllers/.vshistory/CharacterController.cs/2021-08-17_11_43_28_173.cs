using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Domain.Dto.Character;
using RPG.Services.CharacterServices;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [Authorize]
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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var a = await _characterService.GetAllCharacters(id);
            return Ok(a);
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSingle(int id = 0)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCharacter([FromBody] AddCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character));
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody] UpdateCharacterDto updateCharacter)
        {
            var serviceResponse = await _characterService.UpdateCharacter(updateCharacter);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [Route("[action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var serviceResponse = await _characterService.DeleteCharacters(id);
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

    }
}
