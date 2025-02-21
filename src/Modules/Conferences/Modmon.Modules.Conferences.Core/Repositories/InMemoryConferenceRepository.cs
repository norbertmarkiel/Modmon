﻿using Modmon.Modules.Conferences.Core.Entities;

namespace Modmon.Modules.Conferences.Core.Repositories
{
    internal class InMemoryConferenceRepository : IConferencesRepository
    {
        private readonly List<Conference> _conferences = new();

        public Task<Conference> GetAsync(Guid id) => Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

        public async Task<IReadOnlyList<Conference>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _conferences;
        }

        public Task AddAsync(Conference conference)
        {
            _conferences.Add(conference);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Conference conference)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            return Task.CompletedTask;
        }
    }
}
