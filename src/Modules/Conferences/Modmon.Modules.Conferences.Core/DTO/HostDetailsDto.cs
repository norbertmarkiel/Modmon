namespace Modmon.Modules.Conferences.Core.DTO
{
    public class HostDetailsDto : HostDto
    {
        public List<ConferenceDto> Conferences { get; set; }
    }
}
