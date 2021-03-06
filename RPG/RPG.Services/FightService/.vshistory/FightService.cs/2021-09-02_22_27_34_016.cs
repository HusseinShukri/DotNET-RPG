using Microsoft.EntityFrameworkCore;
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
            var attacker = _dataContext.Character.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == weapoAttackDto.AttackerId);
            var oponnent = _dataContext.Character.FirstOrDefaultAsync(c => c.Id == weapoAttackDto.OpponentId);
            throw new System.NotImplementedException();
        }
    }
}
