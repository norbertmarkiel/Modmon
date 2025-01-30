using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Policies
{
    internal interface IHostDeletePolicy
    {
        Task<bool> CanDeleteAsync(Host host);
    }
}
