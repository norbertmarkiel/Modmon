using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Speakers.Core.Exceptions
{
    internal class CannotDeleteSpeakerException : ModmonException
    {
        public Guid Id { get; }

        public CannotDeleteSpeakerException(Guid id) : base($"Speaker with ID: '{id}' cannot be deleted.")
        {
            Id = id;
        }
    }
}
