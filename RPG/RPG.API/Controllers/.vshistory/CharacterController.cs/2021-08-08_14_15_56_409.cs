using Microsoft.AspNetCore.Mvc;
using RPG.API.Models;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character Knight = new Character();

        public IActionResult Get() {
            return Ok(Knight);
        }
        
    }
}
