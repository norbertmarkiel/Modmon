using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Users.Core;
using Modmon.Shared.Abstractions.Modules;

namespace Modmon.Modules.Users.Api
{
    internal class UsersModule : IModule
    {
        public const string BasePath = "users-module";
        public string Name { get; } = "Users";
        public string Path => BasePath;

        public IEnumerable<string> Policies { get; } = new[]
        {
            "users"
        };

        public void Register(IServiceCollection services)
        {
            services.AddCore();
        }

        public void Use(IApplicationBuilder app)
        {
        }
    }
}
