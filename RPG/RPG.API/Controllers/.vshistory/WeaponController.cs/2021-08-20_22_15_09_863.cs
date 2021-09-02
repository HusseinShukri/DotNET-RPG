using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.WeaponRepository;

namespace RPG.API.Controllers
{
    public class WeaponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WeaponRepository weaponRepository;

        public WeaponController(WeaponRepository weaponRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this.weaponRepository = weaponRepository;
        }
    }
}
