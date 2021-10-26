namespace ProjectK.Contracts
{
    public class StatisticsDto
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}