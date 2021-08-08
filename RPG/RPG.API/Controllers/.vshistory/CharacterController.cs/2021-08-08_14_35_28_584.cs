using Microsoft.AspNetCore.Mvc;
using RPG.API.Models;
using System.Collections.Generic;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> KnightList = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };

        [Route("[action]")]
        public IActionResult GetAll()
        {
            return Ok(Knights);
        }

        [Route("[action]")]
        public IActionResult GetSingle([FromHeader] int id) { 
            var result = KnightList.Find(c => c.Id == id);
            return Ok(result);
        }

    }
}
