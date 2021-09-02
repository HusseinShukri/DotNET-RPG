using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Domain.Dto.Character;
using RPG.Services.CharacterService;
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

        [HttpPost("action")]
        public async Task<IActionResult> AddCharacterSkill([FromBody] AddCharacterSkill newCharacterSkill)
        {
            var responce = await _characterSkillService.AddCharacterSkill(newCharacterSkill, getUserId());
            if (!responce.Success)
            {
                return BadRequest(responce);
            }
            return Ok(responce);
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody] CharacterDto updateCharacter)
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
