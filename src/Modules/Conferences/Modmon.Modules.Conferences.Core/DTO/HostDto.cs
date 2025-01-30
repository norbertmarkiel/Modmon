namespace Modmon.Modules.Conferences.Core.DTO
{
    public class HostDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class HostDetailsDto : HostDto
    {
        public List<ConferencesDto> Conferences { get; set; }
    }
}
