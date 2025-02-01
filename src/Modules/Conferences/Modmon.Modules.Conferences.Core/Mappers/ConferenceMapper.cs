using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Mappers
{
    public static class ConferenceMapper
    {
        public static Conference ToEntity(this ConferenceDto dto)
        {
            return new Conference
            {
                Id = dto.Id,
                HostId = dto.HostId,
                Name = dto.Name,
                Location = dto.Location,
                LogoUrl = dto.LogoUrl,
                ParticipantsLimit = dto.ParticipantsLimit,
                From = dto.From,
                To = dto.To
            };
        }

        public static ConferenceDto ToDto(this Conference entity)
        {
            return new ConferenceDto
            {
                Id = entity.Id,
                HostId = entity.HostId,
                Name = entity.Name,
                HostName = entity.Host.Name,
                Location = entity.Location,
                LogoUrl = entity.LogoUrl,
                ParticipantsLimit = entity.ParticipantsLimit,
                From = entity.From,
                To = entity.To
            };
        }

        public static ConferenceDetailsDto ToDetailsDto(this Conference entity)
        {
            return new ConferenceDetailsDto
            {
                Description = entity.Description,
                Id = entity.Id,
                HostId = entity.HostId,
                Name = entity.Name,
                HostName = entity.Host.Name,
                Location = entity.Location,
                LogoUrl = entity.LogoUrl,
                ParticipantsLimit = entity.ParticipantsLimit,
                From = entity.From,
                To = entity.To
            };
        }
    }
}
