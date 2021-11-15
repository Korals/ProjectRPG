using ProjectK.Contracts;
using System.Threading.Tasks;

namespace ProjectK.Business.ExperiencePoints
{
    public interface IExperienceService
    {
        Task<ExperienceDto> GetCharacterLevelAsync(int charId);
        Task<ExperienceDto> GetXpToLevelAsync(int charId);
        Task<ExperienceDto> GetLevelUpAsync(int charId);
        Task<ExperienceDto> GenerateExperienceToLevelAsync(ExperienceDto model);
    }
}
