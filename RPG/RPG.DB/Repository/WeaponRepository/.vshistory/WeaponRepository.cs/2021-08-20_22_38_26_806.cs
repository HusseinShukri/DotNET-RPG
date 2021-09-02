using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Entities;
using RPG.Domain.Response;
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

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon, int userId)
        {
            ServiceResponse<GetCharacterDto> response = new();
            var character = await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.UserId == userId);
            if (character == null)
            {
                response.Success = false;
                response.Message = "No such character.";
                return response;
            }

            Weapon weapon =
            await _dataContext.Weapon.AddAsync(Weapon);
            await _dataContext.SaveChangesAsync();

            response.Data = _mapper.Map<GetCharacterDto>(character);
            response.Message = "new Weapon is here.";
            return response;
        }
    }
}
