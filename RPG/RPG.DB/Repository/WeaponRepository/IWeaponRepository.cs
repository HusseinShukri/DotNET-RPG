using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Response;
using System.Threading.Tasks;

namespace RPG.Data.Repository.WeaponRepository
{
    public interface IWeaponRepository
    {
        Task<ServiceResponse<CharacterDto>> AddWeapon(AddWeaponDto newWeapon, int userId);
    }
}
