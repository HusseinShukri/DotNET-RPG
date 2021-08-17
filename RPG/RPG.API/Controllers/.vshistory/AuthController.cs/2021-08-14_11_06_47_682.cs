using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.AuthRepository;
using RPG.Domain.DTO.User;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthControler : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthControler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IActionResult> Register([FromBody] UserRegisterDto )
        {
            return null;
        }
    }
}
