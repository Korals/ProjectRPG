using ProjectK.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectK.Business.ExperiencePoints
{
    public interface IExperienceEdit
    {
        IExperienceEdit ForChar(int charId);
        IExperienceEdit WithXpToLevel(ExperienceDto experience);
    }
    public class Experience : IExperienceEdit
    {
        [Key]
        public int Level { get; set; }
        public int XpToLevel { get; set; }
        public int CurrentXP { get; set; }
        public int CharacterId { get; set; }
        public Experience()
        {
        }

        public Experience(ExperienceDto exp)
        {
            if (exp is null) throw new ArgumentNullException(nameof(exp));

            CurrentXP = exp.CurrentXp;
            XpToLevel = exp.XpToLevel;
        }

        public ExperienceDto ToDto() => new()
        {
            CurrentXp = CurrentXP,
            XpToLevel = XpToLevel,
        };

        public void UpdateXp(ExperienceDto experience)
        {
            if (experience is null) throw new ArgumentNullException(nameof(experience));

            CurrentXP = experience.CurrentXp;
        }

        public IExperienceEdit ForChar(int charId)
        {
            if (charId <= 0) throw new ArgumentOutOfRangeException(nameof(charId));

            CharacterId = charId;
            
            return this;
        }

        public IExperienceEdit WithXpToLevel(ExperienceDto experience)
        {
            XpToLevel = experience.XpToLevel;

            return this;
        }

    }
}
