namespace Modmon.Shared.Abstractions.Contexts
{
    internal interface IContext
    {
        string RequestId { get; }
        string TraceId { get; }
        IIdentityContext Identity { get; }
    }
}
