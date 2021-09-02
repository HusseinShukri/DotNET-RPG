using RPG.Domain.DTO.Fight;
using RPG.Domain.Response;
using System.Threading.Tasks;

namespace RPG.Services.FightService
{
    public interface IFightService
    {

        Task<ServiceResponse<AttackResultDto>> WeaponAttack();
    }
}
