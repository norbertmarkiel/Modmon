using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Speakers.Core.Exceptions
{
    public class SpeakerNotFoundException : ModmonException
    {
        public SpeakerNotFoundException(Guid id) : base($" Host with Id {id} was not found")
        {
        }
    }
}
