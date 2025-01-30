using Modmon.Shared.Abstractions;

namespace Modmon.Shared.Infrastructure.Time
{
    internal class Clock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}
