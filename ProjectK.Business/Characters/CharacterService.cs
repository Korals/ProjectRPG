using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectK.Business.Stats;
using ProjectK.Business.Weapons;
using ProjectK.Contracts;

namespace ProjectK.Business.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly ILogger<CharacterService> _logger;
        private readonly ICharacterRepository _repository;
        private readonly IWeaponService _weaponService;

        public CharacterService(ILogger<CharacterService> logger, ICharacterRepository repository,
            IWeaponService weaponService)
        {
            _logger = logger;
            _repository = repository;
            _weaponService = weaponService;
        }

        public async Task<CharacterDto> GetCharacterByIdAsync(int id)
        {
            _logger.LogInformation("Get character by id: {Id}", id);

            var character = await _repository.GetCharacterByIdAsync(id);

            return character?.ToDto();
        }

        public async Task<CharacterDto> CreateCharacterAsync(CharacterDto model)
        {
            _logger.LogInformation("Create character with name: {Name}", model?.Name);

            if (model == null) throw new ArgumentNullException(nameof(model));

            var character = new Character();

            var (hitPoints, strength, defence, intelligence) = StatsGenerator.GenerateRandomStats();

            character.ByUser(model.UserId)
                .WithName(model.Name)
                .WithCombatStats(hitPoints, strength, defence, intelligence);

            await _repository.SaveCharacterAsync(character);

            return character.ToDto();
        }

        public async Task<CharacterDto> UpdateCharacterByIdAsync(int id, CharacterDto model)
        {
            _logger.LogInformation("Update character by id: {Id}", id);

            if (model == null) throw new ArgumentNullException(nameof(model));

            var character = await _repository.GetCharacterByIdAsync(id, true);

            if (character == null) return null;

            var weapon = await _weaponService.GetWeaponByIdAsync((model.Weapon?.Id).GetValueOrDefault(0));

            // TODO: get userId from http context
            character.ByUser(model.UserId)
                .WithName(model.Name)
                .WithCombatStats(model.HitPoints, model.Strength, model.Defence, model.Intelligence)
                .WithWeapon(weapon);

            await _repository.SaveCharacterAsync(character);

            character = await _repository.GetCharacterByIdAsync(id);

            return character.ToDto();
        }

        public async Task<bool> DeleteCharacterByIdAsync(int id)
        {
            _logger.LogInformation("Delete character by id: {Id}", id);

            var character = await _repository.GetCharacterByIdAsync(id);

            if (character == null) return false;

            await _repository.DeleteCharacterByIdAsync(character);

            return true;
        }
    }
}