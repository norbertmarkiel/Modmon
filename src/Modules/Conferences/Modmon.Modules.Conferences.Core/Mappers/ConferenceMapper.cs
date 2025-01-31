using Modmon.Modules.Conferences.Core.DTO;
using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Mappers
{
    public static class ConferenceMapper
    {
        public static Conference ToEntity(this ConferenceDto dto, Guid id)
        {
            return new Conference
            {
                Id = id
            };
        }
    }
}
