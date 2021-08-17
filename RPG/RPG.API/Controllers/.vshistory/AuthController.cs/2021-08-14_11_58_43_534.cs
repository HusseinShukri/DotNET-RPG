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
            ServiceResponse<int> response = await _authRepository.Regester(new User { Name = requist.Name }, requist.password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            ServiceResponse<string> response = _authRepository.Login(userLoginDto.Name, userLoginDto.password);

        }
    }
}
