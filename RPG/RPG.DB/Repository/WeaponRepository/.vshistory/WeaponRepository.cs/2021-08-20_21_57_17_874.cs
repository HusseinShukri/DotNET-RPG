using AutoMapper;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Response;
using System;
using System.Threading.Tasks;

namespace RPG.Data.Repository.WeaponRepository
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public WeaponRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            throw new NotImplementedException();
        }
    }
}
