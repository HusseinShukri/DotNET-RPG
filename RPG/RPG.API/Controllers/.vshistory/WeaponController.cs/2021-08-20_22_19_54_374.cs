using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.WeaponRepository;
using RPG.Domain.DTO.Weapon;
using System.Linq;
using System.Security.Claims;
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

        private int getUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddWeapon([FromBody] AddWeaponDto newWeapon)
        {
            await _weaponRepository.AddWeapon(newWeapon, getUserId());
            return null;

        }

    }
}
