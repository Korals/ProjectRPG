using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Business.ExperiencePoints
{
    public interface IExperienceRepository
    {
        Task<Experience> GetCharacterXpToLevelAsync(int charId);
        Task<Experience> GetCharacterCurrentXpAsync(int charId);
        Task<Experience> GetCharacterLevelAsync(int charId);
        Task SaveCharacterXp();
        Task SaveXpToLevel(Experience experience);
    }
}
