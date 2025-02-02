using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Repositories
{
    internal interface IHostsRepository
    {
        Task<Host?> GetAsync(Guid id);
        Task<IReadOnlyList<Host>> BrowseAsync();
        Task AddAsync(Host host);
        Task UpdateAsync(Host host);
        Task DeleteAsync(Host host);
    }
}
