namespace Modmon.Modules.Users.Core.Events
{
    internal record SignedUp(Guid UserId, string Email) : IEvent;
}
