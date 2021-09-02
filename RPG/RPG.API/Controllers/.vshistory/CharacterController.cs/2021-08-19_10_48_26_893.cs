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

        private int getUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _characterService.GetAllCharacters(getUserId()));
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetSingle(int id = 0)
        {
            return Ok(await _characterService.GetCharacterById(id, getUserId()));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCharacter([FromBody] AddCharacterDto character)
        {
            return Ok(await _characterService.AddCharacter(character, getUserId()));
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody] UpdateCharacterDto updateCharacter)
        {
            var serviceResponse = await _characterService.UpdateCharacter(updateCharacter, getUserId());
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
            var serviceResponse = await _characterService.DeleteCharacters(id, getUserId());
            if (!serviceResponse.Success)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
