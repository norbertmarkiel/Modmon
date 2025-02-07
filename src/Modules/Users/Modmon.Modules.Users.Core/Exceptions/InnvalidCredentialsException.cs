using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Users.Core.Exceptions
{
    internal class InvalidCredentialsException : ModmonException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {
        }
    }
}
