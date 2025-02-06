using Modmon.Modules.Speakers.Core.Entities;

namespace Modmon.Modules.Speakers.Core.Repositories
{
    public interface ISpeakersRepository
    {
        Task<Speaker> GetAsync(Guid id);
        Task<IReadOnlyList<Speaker>> BrowseAsync();
        Task AddAsync(Speaker speaker);
        Task UpdateAsync(Speaker speaker);
        Task DeleteAsync(Speaker speaker);
    }
}
