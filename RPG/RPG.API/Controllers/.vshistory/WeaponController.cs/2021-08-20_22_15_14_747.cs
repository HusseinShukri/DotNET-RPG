using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RPG.Data.Repository.WeaponRepository;

namespace RPG.API.Controllers
{
    public class WeaponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WeaponRepository _weaponRepository;

        public WeaponController(WeaponRepository weaponRepository, IMapper mapper)
        {
            _mapper = mapper;
            this._weaponRepository = weaponRepository;
        }
    }
}
