using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Business.ExperiencePoints
{
    public interface IExperienceRepository
    {
        Task<Experience> GetCharacterXpToLevel(int charId);
        Task<Experience> GetCharacterCurrentXp(int charId);
        Task<Experience> GetCharacterLevel(int charId);
        Task SaveCharacterXp();
        Task SaveXpToLevel(Experience experience);
    }
}
