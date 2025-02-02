using Microsoft.EntityFrameworkCore;
using Modmon.Modules.Conferences.Core.Entities;
using Modmon.Modules.Conferences.Core.Repositories;

namespace Modmon.Modules.Conferences.Core.DAL.Repositories
{
    public class ConferencesRepository : IConferencesRepository
    {
        private readonly ConferencesDbContext _context;
        private readonly DbSet<Conference> _conferences;
        public ConferencesRepository(ConferencesDbContext context)
        {
            _context = context;
            _conferences = _context.Conferences;
        }
        public async Task<Conference?> GetAsync(Guid id)
            => await _conferences.SingleOrDefaultAsync(x => x.Id.Equals(id));
        public async Task<IReadOnlyList<Conference>> BrowseAsync()
            => await _conferences.ToListAsync();


        public async Task AddAsync(Conference conference)
        {
            await _conferences.AddAsync(conference);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conference conference)
        {
            _conferences.Update(conference);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            await _context.SaveChangesAsync();
        }

    }
}
