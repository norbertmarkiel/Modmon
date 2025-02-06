using Modmon.Modules.Speakers.Core.DTO;

namespace Modmon.Modules.Speakers.Core.Services
{
    public interface ISpeakersService
    {
        Task AddAsync(SpeakerDetailsDto dto);
        Task<SpeakerDetailsDto> GetAsync(Guid id);
        Task<IReadOnlyList<SpeakerDto>> BrowseAsync();
        Task UpdateAsync(SpeakerDetailsDto dto);
        Task DeleteAsync(Guid id);
    }
}
