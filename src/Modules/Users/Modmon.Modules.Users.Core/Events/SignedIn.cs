namespace Modmon.Modules.Users.Core.Events
{
    internal record SignedIn(Guid UserId) : IEvent;

}
