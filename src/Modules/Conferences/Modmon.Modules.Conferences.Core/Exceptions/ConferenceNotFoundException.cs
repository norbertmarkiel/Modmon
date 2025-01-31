using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Conferences.Core.Exceptions
{
    internal class ConferenceNotFoundException : ModmonException
    {
        public Guid Id { get; }

        public ConferenceNotFoundException(Guid id) : base($"Conference with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
