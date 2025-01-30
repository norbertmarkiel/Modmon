using Modmon.Modules.Conferences.Core.DTO;

namespace Modmon.Modules.Conferences.Core.Services
{
    internal interface IHostService
    {
        Task AddAsync(HostDto dto);
        Task<HostDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyList<HostDto>> BrowseAsync();
        Task UpdateAsync(HostDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}
