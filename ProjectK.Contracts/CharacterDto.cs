using System.Collections.Generic;

namespace ProjectK.Contracts
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int Intelligence { get; set; }
        public int UserId { get; set; }
        public WeaponDto Weapon { get; set; }
        public StatisticsDto Statistics { get; set; }
        public IList<SkillDto> Skills { get; set; }
    }
}