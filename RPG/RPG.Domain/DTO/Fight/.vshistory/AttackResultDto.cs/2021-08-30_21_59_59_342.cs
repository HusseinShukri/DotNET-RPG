﻿namespace RPG.Domain.DTO.Fight
{
    public class AttackResultDto
    {
        public string AttackerName { get; set; }
        public string OponnentName { get; set; }
        public int AttackerHP { get; set; }
        public int OponnentHP { get; set; }
        public int Damage { get; set; }
    }
}
