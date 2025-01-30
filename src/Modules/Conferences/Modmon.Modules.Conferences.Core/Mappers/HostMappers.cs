using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Mappers
{
    public static class HostMappers
    {
        public static Host ToEntity (this HostDto dto, Guid id)
        {
            return new Host
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static HostDto ToDto(this Host entity)
        {
            return new HostDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
        public static HostDetailsDto ToDetailsDto(this Host entity)
        {
            return new HostDetailsDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Conferences = entity.Conferences.Select(entityConference => new ConferencesDto()).ToList(),
            };
        }
    }
}
