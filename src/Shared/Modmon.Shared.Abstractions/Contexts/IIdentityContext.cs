namespace Modmon.Shared.Abstractions.Contexts
{
    internal interface IIdentityContext
    {
        bool IsAuthenticated { get; }
        public Guid Id { get; }
        string Role { get; }
        Dictionary<string, IEnumerable<string>> Claims { get; }
    }
}
