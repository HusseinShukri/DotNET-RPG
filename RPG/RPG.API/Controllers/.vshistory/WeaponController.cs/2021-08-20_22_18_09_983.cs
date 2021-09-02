using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.WeaponRepository;
using System.Threading.Tasks;

namespace RPG.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controller")]

    public class WeaponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WeaponRepository _weaponRepository;

        public WeaponController(WeaponRepository weaponRepository, IMapper mapper)
        {
            _mapper = mapper;
            _weaponRepository = weaponRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddWeapon()
        {

            return null;

        }

    }
}
