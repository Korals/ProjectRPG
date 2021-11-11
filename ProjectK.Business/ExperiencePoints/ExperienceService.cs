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
        private readonly ILogger _logger;

        public ExperienceService(IExperienceRepository repository, ICharacterRepository characterRepository, ILogger logger)
        {
            _repository = repository;
            _characterRepository = characterRepository;
            _logger = logger;
        }


        public async Task<ExperienceDto> GetCharacterLevel(int charId)
        {
            _logger.LogInformation("Get character level: {charId}", charId);

            var charLevel = await _repository.GetCharacterLevel(charId);

            return charLevel?.ToDto();
        }

        public Task<ExperienceDto> GetLevelUp(int charId)
        {
            _logger.LogInformation("Is character ready to levelUp: {charId}", charId);
            var currentXp = _repository.GetCharacterCurrentXp(charId);

        }

        public Task<ExperienceDto> GetXpToLevel(int charId)
        {
            throw new System.NotImplementedException();
        }
        public Task<ExperienceDto> GenerateExperienceToLevel(ExperienceDto model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var experience = new Experience();
            //Generate DB data table

            experience.WithXpToLevel(model.XpToLevel);

            return _repository.SaveXpToLevel(experience);

        }
    }
}
