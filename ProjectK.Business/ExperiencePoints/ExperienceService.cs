using Microsoft.Extensions.Logging;
using ProjectK.Business.Characters;
using ProjectK.Contracts;
using System;
using System.Threading.Tasks;

namespace ProjectK.Business.ExperiencePoints
{
    class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _repository;
        private readonly ICharacterRepository _characterRepository;
        private readonly ILogger<ExperienceService> _logger;

        public ExperienceService(IExperienceRepository repository, ICharacterRepository characterRepository, ILogger<ExperienceService> logger)
        {
            _repository = repository;
            _characterRepository = characterRepository;
            _logger = logger;
        }


        public async Task<ExperienceDto> GetCharacterLevelAsync(int charId)
        {
            _logger.LogInformation("Get character level: {charId}", charId);

            var charLevel = await _repository.GetCharacterLevelAsync(charId);

            return charLevel?.ToDto();
        }

        public async Task<ExperienceDto> GetLevelUpAsync(int charId)
        {
            _logger.LogInformation("Is character ready to levelUp: {charId}", charId);
            var currentXp = _repository.GetCharacterCurrentXpAsync(charId);

        }

        public async Task<ExperienceDto> GetXpToLevelAsync(int charId)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(charId);

             character.Experience.XpToLevel = character.Level == 1 ? 30
                : character.Level == 100 ? 0
                : character.Level >= 50 ? (int)(((character.Level - 1) * (double)1.13) + 30)
                : (int)(((character.Level - 1) * (double)1.15) + 30);

            return character.Experience.XpToLevel;
        }
        public async Task<ExperienceDto> GenerateExperienceToLevelAsync(ExperienceDto model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var experience = new Experience();
            //Generate DB data table

            experience.WithXpToLevel(model.XpToLevel);

            return await _repository.SaveXpToLevel(experience);

        }
    }
}
