﻿using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Entities;
using Modmon.Modules.Conferences.Core.Exceptions;
using Modmon.Modules.Conferences.Core.Policies;
using Modmon.Modules.Conferences.Core.Repositories;

namespace Modmon.Modules.Conferences.Core.Services
{
    internal class ConferencesService : IConferencesService
    {
        private readonly IConferencesRepository _conferenceRepository;
        private readonly IHostsRepository _hostRepository;
        private readonly IConferencesDeletionPolicy _conferenceDeletionPolicy;

        public ConferencesService(IConferencesRepository conferenceRepository, IHostsRepository hostRepository,
            IConferencesDeletionPolicy conferenceDeletionPolicy)
        {
            _conferenceRepository = conferenceRepository;
            _hostRepository = hostRepository;
            _conferenceDeletionPolicy = conferenceDeletionPolicy;
        }

        public async Task AddAsync(ConferenceDetailsDto dto)
        {
            if (await _hostRepository.GetAsync(dto.HostId) is null)
            {
                throw new HostNotFoundException(dto.Id);
            }

            dto.Id = Guid.NewGuid();
            var conference = new Conference
            {
                Id = dto.Id,
                HostId = dto.HostId,
                Name = dto.Name,
                Description = dto.Description,
                From = dto.From,
                To = dto.To,
                Location = dto.Location,
                LogoUrl = dto.LogoUrl,
                ParticipantsLimit = dto.ParticipantsLimit
            };

            await _conferenceRepository.AddAsync(conference);
        }

        public async Task<ConferenceDetailsDto> GetAsync(Guid id)
        {
            var conference = await _conferenceRepository.GetAsync(id);
            if (conference is null)
            {
                return null;
            }

            var dto = Map<ConferenceDetailsDto>(conference);
            dto.Description = conference.Description;

            return dto;
        }

        public async Task<IReadOnlyList<ConferenceDto>> BrowseAsync()
        {
            var conferences = await _conferenceRepository.BrowseAsync();

            return conferences.Select(Map<ConferenceDto>).ToList();
        }

        public async Task UpdateAsync(ConferenceDetailsDto dto)
        {
            var conference = await _conferenceRepository.GetAsync(dto.Id);
            if (conference is null)
            {
                throw new ConferenceNotFoundException(dto.Id);
            }

            conference.Name = dto.Name;
            conference.Description = dto.Description;
            conference.Location = dto.Location;
            conference.LogoUrl = dto.LogoUrl;
            conference.From = dto.From;
            conference.To = dto.To;
            conference.ParticipantsLimit = dto.ParticipantsLimit;
            await _conferenceRepository.UpdateAsync(conference);
        }

        public async Task DeleteAsync(Guid id)
        {
            var conference = await _conferenceRepository.GetAsync(id);
            if (conference is null)
            {
                throw new ConferenceNotFoundException(id);
            }

            if (await _conferenceDeletionPolicy.CanDeleteAsync(conference) is false)
            {
                throw new CannotDeleteConferenceException(id);
            }

            await _conferenceRepository.DeleteAsync(conference);
        }

        private static T Map<T>(Conference conference) where T : ConferenceDto, new()
            => new()
            {
                Id = conference.Id,
                HostId = conference.HostId,
                HostName = conference.Host?.Name,
                Name = conference.Name,
                Location = conference.Location,
                From = conference.From,
                To = conference.To,
                LogoUrl = conference.LogoUrl,
                ParticipantsLimit = conference.ParticipantsLimit
            };
    }
}
