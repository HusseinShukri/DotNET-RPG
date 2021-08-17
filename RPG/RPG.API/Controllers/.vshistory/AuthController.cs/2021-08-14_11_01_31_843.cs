using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.AuthRepository;

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


    }
}
