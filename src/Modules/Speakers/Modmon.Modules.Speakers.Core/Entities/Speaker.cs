using Modmon.Modules.Speakers.Core.DTO;
using System.Security.Policy;

namespace Modmon.Modules.Speakers.Core.Entities
{
    public class Speaker
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string AvatarUrl { get; set; }



        public void UpdateFromDetailsDto(SpeakerDetailsDto speakerDetailsDto) {
            FullName = speakerDetailsDto.FullName;
            Email = speakerDetailsDto.Email;
            Phone = speakerDetailsDto.Phone;
            Biography = speakerDetailsDto.Biography;
            AvatarUrl = speakerDetailsDto.AvatarUrl;
        }
    }
}
