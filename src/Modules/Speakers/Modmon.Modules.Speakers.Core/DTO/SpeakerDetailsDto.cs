namespace Modmon.Modules.Speakers.Core.DTO
{
    public class SpeakerDetailsDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string AvatarUrl { get; set; }
    }
}
