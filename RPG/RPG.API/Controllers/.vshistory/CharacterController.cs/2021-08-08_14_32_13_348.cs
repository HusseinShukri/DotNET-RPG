using Microsoft.AspNetCore.Mvc;
using RPG.API.Models;
using System.Collections.Generic;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> Knight = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };

        [Route("[action]")]
        public IActionResult Get()
        {
            return Ok(Knight);
        }

    }
}
