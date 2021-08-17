using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.AuthRepository;
using RPG.Domain.DTO.User;
using RPG.Domain.Entities;
using RPG.Domain.Response;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto requist)
        {
            User user = new();
            user.Name = requist.Name;
            ServiceResponse<int> response = await _authRepository.Regester(user, requist.password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
