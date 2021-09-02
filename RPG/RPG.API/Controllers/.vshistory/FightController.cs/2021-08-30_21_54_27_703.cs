using Microsoft.AspNetCore.Mvc;
using RPG.Services.FightService;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            this._fightService = fightService;
        }
    }
}
