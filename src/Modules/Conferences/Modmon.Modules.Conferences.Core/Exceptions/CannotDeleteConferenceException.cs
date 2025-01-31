using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteConferenceException : ModmonException
    {
        public Guid Id { get; }

        public CannotDeleteConferenceException(Guid id) : base($"Conference with ID: '{id}' cannot be deleted.")
        {
            Id = id;
        }
    }
}
