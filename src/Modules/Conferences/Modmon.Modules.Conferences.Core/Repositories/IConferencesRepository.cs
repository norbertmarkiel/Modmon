using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Repositories
{
    internal interface IConferencesRepository
    {
        Task<Conference> GetAsync(Guid id);
        Task<IReadOnlyList<Conference>> BrowseAsync();
        Task AddAsync(Conference conference);
        Task UpdateAsync(Conference conference);
        Task DeleteAsync(Conference conference);
    }
}
