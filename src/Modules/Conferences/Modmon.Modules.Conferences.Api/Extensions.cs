using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Conferences.Core;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Modmon.Bootstraper")]
namespace Modmon.Modules.Conferences.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddConferences(this IServiceCollection services)
        {
            services.AddCore();

            return services;
        }
    }
}
