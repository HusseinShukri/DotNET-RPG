using Microsoft.AspNetCore.Mvc;
using RPG.Services.CharacterSkillService;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;

        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            this._characterSkillService = characterSkillService;
        }
    }
}
