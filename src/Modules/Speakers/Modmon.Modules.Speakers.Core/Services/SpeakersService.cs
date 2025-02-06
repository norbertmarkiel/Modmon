using Modmon.Modules.Speakers.Core.DTO;
using Modmon.Modules.Speakers.Core.Exceptions;
using Modmon.Modules.Speakers.Core.Mappers;
using Modmon.Modules.Speakers.Core.Policies;
using Modmon.Modules.Speakers.Core.Repositories;

namespace Modmon.Modules.Speakers.Core.Services
{
    internal class SpeakersService : ISpeakersService
    {
        private readonly ISpeakersRepository _speakerRepository;
        private readonly ISpeakersDeletionPolicy _speakerDeletionPolicy;

        public SpeakersService(ISpeakersRepository speakerRepository,
            ISpeakersDeletionPolicy speakerDeletionPolicy
            )
        {
            _speakerRepository = speakerRepository;
            _speakerDeletionPolicy = speakerDeletionPolicy;
        }

        public async Task AddAsync(SpeakerDetailsDto dto)
        {
            if (await _speakerRepository.GetAsync(dto.Id) is null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }

            dto.Id = Guid.NewGuid();
            var speaker = dto.ToEntity();
            await _speakerRepository.AddAsync(speaker);
        }

        public async Task<SpeakerDetailsDto> GetAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            if (speaker is null)
            {
                return null;
            }
            var dto = speaker.ToDetailDto();

            return dto;
        }

        public async Task<IReadOnlyList<SpeakerDto>> BrowseAsync()
        {
            var speakers = await _speakerRepository.BrowseAsync();

            return speakers.Select(x=>x.ToDto()).ToList();
        }

        public async Task UpdateAsync(SpeakerDetailsDto dto)
        {
            var speaker = await _speakerRepository.GetAsync(dto.Id);
            if (speaker is null)
            {
                throw new SpeakerNotFoundException(dto.Id);
            }

            speaker.UpdateFromDetailsDto(dto); 

            await _speakerRepository.UpdateAsync(speaker);
        }

        public async Task DeleteAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);
            if (speaker is null)
            {
                throw new SpeakerNotFoundException(id);
            }

            if (await _speakerDeletionPolicy.CanDeleteAsync(speaker) is false)
            {
                throw new CannotDeleteSpeakerException(id);
            }

            await _speakerRepository.DeleteAsync(speaker);
        }
    }
}
