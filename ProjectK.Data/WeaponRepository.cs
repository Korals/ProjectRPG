using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectK.Business.Weapons;

namespace ProjectK.Data
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ProjectKContext _context;

        public WeaponRepository(ProjectKContext context)
        {
            _context = context;
        }

        public Task<Weapon> GetWeaponByIdAsync(int id, bool write = false)
        {
            var query = _context.Weapons.AsQueryable();

            if (write == false)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveWeaponAsync(Weapon character)
        {
            if (character.Id <= 0)
                _context.Weapons.Add(character);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeaponByIdAsync(Weapon character)
        {
            _context.Weapons.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}