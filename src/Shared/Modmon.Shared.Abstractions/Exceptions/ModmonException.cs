namespace Modmon.Shared.Abstractions.Exceptions
{
    public abstract class ModmonException : Exception
    {
        protected ModmonException(string message) : base(message)
        {
        }
    }
}
