﻿using RPG.Domain.DTO.Fight;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeapoAttackDto weapoAttackDto);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto skillAttackDto);
        Task<ServiceResponse<FightResultDto>> FightAttack(FightRequistDto fightRequistDto);
        Task<ServiceResponse<List<HighScoreDato>>> GetHighScore();
    }
}
