using Modmon.Modules.Speakers.Core.DTO;
using Modmon.Modules.Speakers.Core.Entities;

namespace Modmon.Modules.Speakers.Core.Mappers
{
    public static class SpeakersMapper
    {
        public static Speaker ToEntity(this SpeakerDto dto)
        {
            return new Speaker
            {
                Id = dto.Id
            };
        }

        public static Speaker ToEntity(this SpeakerDetailsDto dto)
        {
            return new Speaker
            {
                Id = dto.Id
            };
        }

        public static SpeakerDto ToDto(this Speaker entity)
        {
            return new SpeakerDto
            {
                Id = entity.Id
            };
        }

        public static SpeakerDetailsDto ToDetailDto(this Speaker entity)
        {
            return new SpeakerDetailsDto
            {
                Id = entity.Id
            };
        }
    }


}
