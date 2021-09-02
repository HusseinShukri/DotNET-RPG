using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Domain.DTO.Fight;
using RPG.Domain.Response;
using System;
using System.Linq;
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

        private int WeaponDamage(int attackerWeaponDamage, int attackerStringth, int oponnentDefense)
        {
            return attackerWeaponDamage + RandomNumber(attackerStringth) - RandomNumber(oponnentDefense);
        }

        private int SkillDamage(int attackerSkillDamage, int attackerIntelligence, int oponnentDefense)
        {
            return attackerSkillDamage + new Random().Next(attackerIntelligence) - new Random().Next(oponnentDefense);
        }

        private int RandomNumber(int max)
        {

            return new Random().Next(max);
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeapoAttackDto weapoAttackDto)
        {
            var attacker = await _dataContext.Character.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == weapoAttackDto.AttackerId);
            var oponnent = await _dataContext.Character.AsTracking().FirstOrDefaultAsync(c => c.Id == weapoAttackDto.OpponentId);
            ServiceResponse<AttackResultDto> responce = new();
            if (attacker == null || oponnent == null) { responce.Success = false; responce.Message = "Character missing"; return responce; }
            int damage = NewMethod(attacker, oponnent);
            if (oponnent.HitPoints <= 0) { responce.Message = $"Character {oponnent.Name} was defeated"; }
            await _dataContext.SaveChangesAsync();
            responce.Data = new AttackResultDto
            {
                AttackerName = attacker.Name,
                AttackerHP = attacker.HitPoints,
                OpponentName = oponnent.Name,
                OpponentHP = oponnent.HitPoints,
                Damage = damage
            };
            return responce;
        }

        private int NewMethod(Domain.Entities.Character attacker, Domain.Entities.Character oponnent)
        {
            int damage = WeaponDamage(attacker.Weapon.Damage, attacker.Strength, oponnent.Defeats);
            if (damage > 0) { oponnent.HitPoints -= damage; }

            return damage;
        }

        public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto skillAttackDto)
        {
            var attacker = await _dataContext.Character.Include(c => c.Skills).FirstOrDefaultAsync(c => c.Id == skillAttackDto.AttackerId);
            var oponnent = await _dataContext.Character.AsTracking().FirstOrDefaultAsync(c => c.Id == skillAttackDto.OpponentId);
            ServiceResponse<AttackResultDto> responce = new();
            if (attacker == null || oponnent == null) { responce.Success = false; responce.Message = "Character missing"; return responce; }
            var skill = attacker.Skills.FirstOrDefault(s => s.Id == skillAttackDto.SkillId);
            if (skill == null) { responce.Success = false; responce.Message = $"Character {attacker.Name} does not have the wanted skill"; return responce; }
            int damage = SkillDamage(skill.Damage, attacker.Intelligence, oponnent.Defeats);
            if (damage > 0) { oponnent.HitPoints -= damage; }
            if (oponnent.HitPoints <= 0) { responce.Message = $"Character {oponnent.Name} was defeated"; }
            await _dataContext.SaveChangesAsync();
            responce.Data = new AttackResultDto
            {
                AttackerName = attacker.Name,
                AttackerHP = attacker.HitPoints,
                OpponentName = oponnent.Name,
                OpponentHP = oponnent.HitPoints,
                Damage = damage
            };
            return responce;
        }

        public async Task<ServiceResponse<FightResultDto>> FightAttack(FightRequistDto fightRequistDto)
        {
            ServiceResponse<FightResultDto> responce = new()
            {
                Data = new FightResultDto()
            };

            var characters = await _dataContext.Character
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .Where(c => fightRequistDto.CharacterIds.Contains(c.Id))
                .ToListAsync();

            bool defeted = false;
            while (!defeted)
            {

                foreach (var attacker in characters)
                {
                    var oponnents = characters.Where(c => c.Id != attacker.Id).ToList();
                    var oponnent = oponnents[RandomNumber(oponnents.Count)];

                    int damage = 0;
                    string attackUsed = string.Empty;
                    bool useWeapon = RandomNumber(2) == 0;
                    if (useWeapon)
                    {
                        attackUsed = attacker.Weapon.Name;
                    }
                    else
                    {
                    }
                }

            }

            throw new NotImplementedException();
        }
    }
}
