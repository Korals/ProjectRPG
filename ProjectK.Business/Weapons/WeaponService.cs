using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectK.Contracts;

namespace ProjectK.Business.Weapons
{
    public class WeaponService : IWeaponService
    {
        private readonly ILogger<WeaponService> _logger;
        private readonly IWeaponRepository _repository;

        public WeaponService(ILogger<WeaponService> logger, IWeaponRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<WeaponDto> GetWeaponByIdAsync(int id)
        {
            _logger.LogInformation("Get weapon by id: {Id}", id);

            var weapon = await _repository.GetWeaponByIdAsync(id);

            return weapon?.ToDto();
        }

        public async Task<WeaponDto> CreateWeaponAsync(WeaponDto model)
        {
            _logger.LogInformation("Create weapon with name: {Name}", model?.Name);

            if (model == null) throw new ArgumentNullException(nameof(model));

            var weapon = new Weapon(model);

            await _repository.SaveWeaponAsync(weapon);

            return weapon.ToDto();
        }

        public async Task<WeaponDto> UpdateWeaponByIdAsync(int id, WeaponDto model)
        {
            _logger.LogInformation("Update weapon by id: {Id}", id);

            if (model == null) throw new ArgumentNullException(nameof(model));

            var weapon = await _repository.GetWeaponByIdAsync(id, true);

            if (weapon == null) return null;

            weapon.Update(model);

            await _repository.SaveWeaponAsync(weapon);

            weapon = await _repository.GetWeaponByIdAsync(id);

            return weapon.ToDto();
        }

        public async Task<bool> DeleteWeaponByIdAsync(int id)
        {
            _logger.LogInformation("Delete weapon by id: {Id}", id);

            var weapon = await _repository.GetWeaponByIdAsync(id);

            if (weapon == null) return false;

            await _repository.DeleteWeaponByIdAsync(weapon);

            return true;
        }
    }
}