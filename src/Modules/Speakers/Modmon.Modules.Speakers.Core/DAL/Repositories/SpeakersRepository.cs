using Microsoft.EntityFrameworkCore;
using Modmon.Modules.Speakers.Core.Entities;
using Modmon.Modules.Speakers.Core.Repositories;

namespace Modmon.Modules.Speakers.Core.DAL.Repositories
{

    public class SpeakersRepository : ISpeakersRepository
    {
        private readonly SpeakersDbContext _context;
        private readonly DbSet<Speaker> _speakers;
        public SpeakersRepository(SpeakersDbContext context)
        {
            _context = context;
            _speakers = _context.Speakers;
        }
        public async Task<Speaker?> GetAsync(Guid id)
            => await _speakers.SingleOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<IReadOnlyList<Speaker>> BrowseAsync()
            => await _speakers.ToListAsync();

        public async Task AddAsync(Speaker speaker)
        {
            await _speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Speaker speaker)
        {
            _speakers.Update(speaker);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Speaker speaker)
        {
            _speakers.Remove(speaker);
            await _context.SaveChangesAsync();
        }
    }
}
