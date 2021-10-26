using ProjectK.Business.Characters;
using ProjectK.Contracts;

namespace ProjectK.Business
{
    public class Statistics
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public Character Character { get; private set; }
        public int Fights { get; private set; }
        public int Victories { get; private set; }
        public int Defeats { get; private set; }

        public void UpdateStatistics(StatisticsDto statistics)
        {
            Fights = statistics.Fights;
            Victories = statistics.Victories;
            Defeats = statistics.Defeats;
        }

        public StatisticsDto ToDto() => new()
        {
            Id = Id,
            CharacterId = CharacterId,
            Fights = Fights,
            Victories = Victories,
            Defeats = Defeats,
        };
    }
}