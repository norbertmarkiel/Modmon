using Modmon.Modules.Conferences.Core.DTO;

namespace Modmon.Modules.Conferences.Core.Services
{
    public interface IConferencesService
    {
        Task AddAsync(ConferenceDetailsDto dto);
        Task<ConferenceDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyList<ConferenceDto>> BrowseAsync();
        Task UpdateAsync(ConferenceDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}
