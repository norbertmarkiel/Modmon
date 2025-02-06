using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Speakers.Core;
using Modmon.Shared.Abstractions.Modules;

namespace Modmon.Modules.Speakers.Api
{

    internal class SpeakersModule : IModule
    {
        public const string BasePath = "conferences";
        public string Name => "conferences-module";
        public string Path => BasePath;

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
        }
    }
}
