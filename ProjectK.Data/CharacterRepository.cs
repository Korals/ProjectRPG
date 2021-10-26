using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectK.Business.Characters;

namespace ProjectK.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ProjectKContext _context;

        public CharacterRepository(ProjectKContext context)
        {
            _context = context;
        }

        public Task<Character> GetCharacterByIdAsync(int id, bool write = false)
        {
            // TODO: uncomment after refactoring
            var query = _context.Characters
                // .Include(c => c.Statistics)
                // .Include(c => c.Skills)
                .Include(c => c.Weapon)
                .AsQueryable();

            if (write == false)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveCharacterAsync(Character character)
        {
            if (character.Id <= 0)
                _context.Characters.Add(character);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCharacterByIdAsync(Character character)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}