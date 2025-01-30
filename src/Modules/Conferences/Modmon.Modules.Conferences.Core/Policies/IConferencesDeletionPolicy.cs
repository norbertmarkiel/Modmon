using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Policies
{
    internal interface IConferencesDeletionPolicy
    {
        Task<bool> CanDeleteAsync(Conference conference);

    }
}
