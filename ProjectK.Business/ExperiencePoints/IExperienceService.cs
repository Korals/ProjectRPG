using ProjectK.Contracts;
using System.Threading.Tasks;

namespace ProjectK.Business.ExperiencePoints
{
    public interface IExperienceService
    {
        Task<ExperienceDto> GetCharacterLevel(int charId);
        Task<ExperienceDto> GetXpToLevel(int charId);
        Task<ExperienceDto> GetLevelUp(int charId);
        Task<ExperienceDto> GenerateExperienceToLevel(ExperienceDto model);
    }
}
