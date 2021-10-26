using System.Threading.Tasks;

namespace ProjectK.Business.Weapons
{
    public interface IWeaponRepository
    {
        Task<Weapon> GetWeaponByIdAsync(int id, bool write = false);
        Task SaveWeaponAsync(Weapon character);
        Task DeleteWeaponByIdAsync(Weapon character);
    }
}