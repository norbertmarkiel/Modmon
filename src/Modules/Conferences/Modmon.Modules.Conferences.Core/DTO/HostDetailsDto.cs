namespace Modmon.Modules.Conferences.Core.DTO
{
    public class HostDetailsDto : HostDto
    {
        public List<ConferencesDto> Conferences { get; set; }
    }
}
