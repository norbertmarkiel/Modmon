using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Conferences.Core.DAL;
using Modmon.Modules.Conferences.Core.DAL.Repositories;
using Modmon.Modules.Conferences.Core.Policies;
using Modmon.Modules.Conferences.Core.Repositories;
using Modmon.Modules.Conferences.Core.Services;
using Modmon.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Modmon.Modules.Conferences.Api")]
namespace Modmon.Modules.Conferences.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<ConferencesDbContext>();
            //services.AddSingleton<IHostsRepository, InMemoryHostRepository>();
            services.AddScoped<IHostsRepository, HostsRepository>();
            services.AddSingleton<IConferencesDeletionPolicy, ConferencesDeletionPolicy>();
            services.AddSingleton<IHostDeletePolicy, HostDeletePolicy>();
            services.AddScoped<IHostService, HostService>();

            //services.AddSingleton<IConferencesRepository, InMemoryConferenceRepository>();
            services.AddScoped<IConferencesRepository, ConferencesRepository>();
            services.AddScoped<IConferencesService, ConferencesService>();
            return services;
        }
    }
}
