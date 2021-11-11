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


        public Task<Experience> GetCharacterCurrentXp(int charId)
        {
            var querry = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.CurrentXP)
                .AsQueryable();

            return querry.FirstOrDefaultAsync(c => c.CharacterId == charId);
        }

        public Task<Experience> GetCharacterLevel(int charId)
        {
            var querry = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.Level)
                .AsQueryable();

            return querry.FirstOrDefaultAsync(c => c.CharacterId == charId);
        }

        public Task<Experience> GetCharacterXpToLevel(int charId)
        {
            var querry = _context.Experiences
                .Include(c => c.CharacterId)
                .Include(c => c.XpToLevel)
                .AsQueryable();

            var level = querry.FirstOrDefault(c => c.CharacterId == charId).Level;

            var xpToLevel = level == 1 ? 30 
                : level == 100 ? 0 
                : level >= 50 ? (int)(((level - 1) * (double)1.13) + 30) 
                : (int)(((level - 1) * (double)1.15) + 30);

            
            
            return 0;
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
