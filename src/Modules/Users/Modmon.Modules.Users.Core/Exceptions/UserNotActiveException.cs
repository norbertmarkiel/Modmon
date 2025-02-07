using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Users.Core.Exceptions
{
    internal class UserNotActiveException : ModmonException
    {
        public Guid UserId { get; }

        public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active.")
        {
            UserId = userId;
        }
    }
}
