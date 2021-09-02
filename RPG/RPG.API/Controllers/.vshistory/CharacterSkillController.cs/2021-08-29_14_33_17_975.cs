using Microsoft.AspNetCore.Mvc;
using RPG.Domain.DTO.Skill;
using RPG.Services.CharacterSkillService;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;

        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }

        private int getUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacterSkill([FromBody] AddCharacterSkill newCharacterSkill)
        {
            _characterSkillService.AddCharacterSkill(, getUserId());
            return null;
        }
    }
}
