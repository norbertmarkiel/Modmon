using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Conferences.Core.Exceptions
{
    public class HostNotFoundException : ModmonException
    {
        public HostNotFoundException(Guid id) : base($" Host with Id {id} was not found")
        { 
        }
    }
}
