﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeapoAttackDto weapoAttackDto)
        {
            var attacker = await _dataContext.Character.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == weapoAttackDto.AttackerId);
            var oponnent = await _dataContext.Character.AsTracking().FirstOrDefaultAsync(c => c.Id == weapoAttackDto.OpponentId);
            ServiceResponse<AttackResultDto> responce = new();
            if (attacker == null || oponnent == null) { responce.Success = false; responce.Message = "Character missing"; return responce; }
            int damage = attacker.Weapon.Damage + new Random().Next(attacker.Strength) - new Random().Next(oponnent.Defense);
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

        public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(SkillAttackDto skillAttackDto)
        {
            var attacker = await _dataContext.Character.Include(c => c.Skills).FirstOrDefaultAsync(c => c.Id == skillAttackDto.AttackerId);
            var oponnent = await _dataContext.Character.AsTracking().FirstOrDefaultAsync(c => c.Id == skillAttackDto.OpponentId);
            ServiceResponse<AttackResultDto> responce = new();
            if (attacker == null || oponnent == null) { responce.Success = false; responce.Message = "Character missing"; return responce; }
            var skill = attacker.Skills.FirstOrDefault(s => s.Id == skillAttackDto.SkillId);
            if (skill == null) { responce.Success = false; responce.Message = $"Character {attacker.Name} does not have the wanted skill"; return responce; }
            int damage = attacker.Weapon.Damage + new Random().Next(attacker.Strength) - new Random().Next(oponnent.Defense);
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
    }
}
