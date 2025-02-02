using Microsoft.EntityFrameworkCore;
using Modmon.Modules.Conferences.Core.Entities;
using Modmon.Modules.Conferences.Core.Repositories;

namespace Modmon.Modules.Conferences.Core.DAL.Repositories
{
    public class HostsRepository : IHostsRepository
    {
        private readonly ConferencesDbContext _context;
        private readonly DbSet<Host> _hosts;


        //32:35
        public HostsRepository(ConferencesDbContext context)
        {
            _context = context;
            _hosts = _context.Hosts;
        }
        public async Task<Host?> GetAsync(Guid id) 
            => await _hosts.Include(x => x.Conferences).SingleOrDefaultAsync(x => x.Id.Equals(id));
        public async Task<IReadOnlyList<Host>> BrowseAsync()
            => await _hosts.Include(x => x.Conferences).ToListAsync();


        public async Task AddAsync(Host host)
        { 
             await _hosts.AddAsync(host);   
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Host host)
        {
            _hosts.Update(host);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            await _context.SaveChangesAsync();
        }

    }
}
