using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Policies
{
    internal class HostDeletePolicy : IHostDeletePolicy
    {
        private readonly IConferencesDeletionPolicy _conferencesDeletionPolicy;

        public HostDeletePolicy(IConferencesDeletionPolicy conferencesDeletionPolicy)
        {
            _conferencesDeletionPolicy = conferencesDeletionPolicy;
        }


        public async Task<bool> CanDeleteAsync(Host host)
        {
            if (host.Conferences is null || !host.Conferences.Any())
            return true;

            foreach (var item in host.Conferences)
            {
                if (await _conferencesDeletionPolicy.CanDeleteAsync(item) is false)
                    return false;
            }

            return true;
        }
    }
}
