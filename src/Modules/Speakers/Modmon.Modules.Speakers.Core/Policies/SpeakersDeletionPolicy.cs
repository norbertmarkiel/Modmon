using Modmon.Modules.Speakers.Core.Entities;
using Modmon.Shared.Abstractions;

namespace Modmon.Modules.Speakers.Core.Policies
{
    internal class SpeakersDeletionPolicy : ISpeakersDeletionPolicy
    {
        private readonly IClock _clock;

        public SpeakersDeletionPolicy(IClock clock)
        {
            _clock = clock;
        }

        public async Task<bool> CanDeleteAsync(Speaker speaker)
        {
            //TODO check assign to any conferences

            return true;
        }
    }
}
