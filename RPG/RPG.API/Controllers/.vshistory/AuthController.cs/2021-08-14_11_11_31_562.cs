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
    public class AuthControler : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthControler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IActionResult> Register([FromBody] UserRegisterDto requist)
        {
            ServiceResponse<int> response = new();
            User user = new User();
            user.Name = requist.Name;
            response.Data = _authRepository.Regester(user, requist.Passwork);

            return null;
        }
    }
}
