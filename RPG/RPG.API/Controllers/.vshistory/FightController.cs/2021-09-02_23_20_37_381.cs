using Microsoft.AspNetCore.Mvc;
using RPG.Domain.DTO.Fight;
using RPG.Services.FightService;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> WeaponAttack([FromBody] WeapoAttackDto weapoAttackDto)
        {
            return Ok(await _fightService.WeaponAttack(weapoAttackDto));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SkillAttack([FromBody] SkillAttackDto skillAttackDto)
        {
            return Ok(await _fightService.SkillAttack(skillAttackDto));
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> FightAttack([FromBody] SkillAttackDto skillAttackDto)
        {
            return Ok(await _fightService.SkillAttack(skillAttackDto));
        }
    }
}
