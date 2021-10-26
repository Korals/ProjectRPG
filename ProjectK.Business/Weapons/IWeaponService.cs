using System.Threading.Tasks;
using ProjectK.Contracts;

namespace ProjectK.Business.Weapons
{
    public interface IWeaponService
    {
        Task<WeaponDto> GetWeaponByIdAsync(int id);
        Task<WeaponDto> CreateWeaponAsync(WeaponDto model);
        Task<WeaponDto> UpdateWeaponByIdAsync(int id, WeaponDto model);
        Task<bool> DeleteWeaponByIdAsync(int id);
    }
}