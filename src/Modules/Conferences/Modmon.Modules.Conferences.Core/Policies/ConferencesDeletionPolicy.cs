using Modmon.Modules.Conferences.Core.Entities;
using Modmon.Shared.Abstractions;

namespace Modmon.Modules.Conferences.Core.Policies
{
    internal class ConferencesDeletionPolicy : IConferencesDeletionPolicy
    {
        private readonly IClock _clock;

        public ConferencesDeletionPolicy(IClock clock)
        {
            _clock = clock;
        }

        public async Task<bool> CanDeleteAsync(Conference conference)
        {
            //TODO check if there are any participans?
            return _clock.CurrentDate().Date.AddDays(7) < conference.From.Date;
        }
    }
}
