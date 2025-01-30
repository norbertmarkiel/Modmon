using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Conferences.Core.Policies;
using Modmon.Modules.Conferences.Core.Repositories;
using Modmon.Modules.Conferences.Core.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Modmon.Modules.Conferences.Api")]
namespace Modmon.Modules.Conferences.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IHostRepository, InMemoryHostRepository>();
            services.AddSingleton<IConferencesDeletionPolicy, ConferencesDeletionPolicy>();
            services.AddSingleton<IHostDeletePolicy, HostDeletePolicy>();
            services.AddSingleton<IHostService, HostService>();

            return services;
        }
    }
}
