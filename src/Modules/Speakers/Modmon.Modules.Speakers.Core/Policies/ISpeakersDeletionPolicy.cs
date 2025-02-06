using Modmon.Modules.Speakers.Core.Entities;

namespace Modmon.Modules.Speakers.Core.Policies
{
    public interface ISpeakersDeletionPolicy
    {
        Task<bool> CanDeleteAsync(Speaker speaker);

    }
}
