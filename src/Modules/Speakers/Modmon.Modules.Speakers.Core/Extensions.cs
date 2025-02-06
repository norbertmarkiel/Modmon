using Microsoft.Build.Execution;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Speakers.Core.DAL;
using Modmon.Modules.Speakers.Core.DAL.Repositories;
using Modmon.Modules.Speakers.Core.Policies;
using Modmon.Modules.Speakers.Core.Repositories;
using Modmon.Modules.Speakers.Core.Services;
using Modmon.Shared.Infrastructure.Postgres;

namespace Modmon.Modules.Speakers.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddPostgres<SpeakersDbContext>();
            services.AddSingleton<ISpeakersDeletionPolicy, SpeakersDeletionPolicy>();
            services.AddScoped<ISpeakersRepository, SpeakersRepository>();
            services.AddScoped<ISpeakersService, SpeakersService>();

            return services;
        }
    }
}
