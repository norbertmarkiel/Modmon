using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Modules.Users.Core.Exceptions
{
    internal class EmailInUseException : ModmonException
    {
        public EmailInUseException() : base("Email is already in use.")
        {
        }
    }
}
