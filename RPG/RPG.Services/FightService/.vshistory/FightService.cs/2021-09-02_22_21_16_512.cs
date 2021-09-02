using RPG.Data.Context;
using RPG.Domain.DTO.Fight;
using RPG.Domain.Response;
using System.Threading.Tasks;

namespace RPG.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _dataContext;

        public FightService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeapoAttackDto weapoAttackDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
