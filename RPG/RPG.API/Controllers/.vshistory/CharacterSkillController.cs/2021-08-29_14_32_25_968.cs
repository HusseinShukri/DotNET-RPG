using Microsoft.AspNetCore.Mvc;
using RPG.Services.CharacterSkillService;
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
        public async Task<IActionResult> AddCharacterSkill()
        {
            _characterSkillService.AddCharacterSkill();
            return null;
        }
    }
}
