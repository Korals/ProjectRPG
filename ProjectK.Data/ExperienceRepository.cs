using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectK.Business.ExperiencePoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Data
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ProjectKContext _context;

        public ExperienceRepository(ProjectKContext context)
        {
            _context = context;
        }

        public Task<Experience> GetCharacterCurrentXpAsync(int charId)
        {
            var query = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.CurrentXP)
                .AsQueryable();

            return query.FirstOrDefaultAsync(c => c.CharacterId == charId);
        }

        public Task<Experience> GetCharacterLevelAsync(int charId)
        {
            var query = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.Level)
                .AsQueryable();

            return query.FirstOrDefaultAsync(c => c.CharacterId == charId);
        }

        public Task<Experience> GetCharacterXpToLevelAsync(int charId)
        {
            var query = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.XpToLevel)
                .AsQueryable();

            return query.FirstOrDefaultAsync(c => c.CharacterId == charId);
        }

        public Task SaveCharacterXp()
        {
            throw new NotImplementedException();
        }

        public async Task SaveXpToLevel(Experience experience)
        {
            if (experience is null) throw new ArgumentNullException(nameof(experience));

            if (experience.Level <= 0)
                _context.Experiences.Add(experience);

            await _context.SaveChangesAsync();
        }
    }
}
