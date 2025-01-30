using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteHostException : ModmonException
    {
        public Guid Id { get; }
        public CannotDeleteHostException(Guid id) : base($" Host with Id {id} cannot be deleted") 
        {
            Id = id;
        }
    }
}
