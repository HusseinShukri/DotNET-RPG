namespace RPG.Domain.DTO.Fight
{
    public class AttackResultDto
    {
        public string AttackerName { get; set; }
        public string OpponentName { get; set; }
        public int AttackerHP { get; set; }
        public int OpponentHP { get; set; }
        public int Damage { get; set; }
    }
}
