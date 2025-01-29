using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Modmon.Modules.Conferences.Api")]
namespace Modmon.Modules.Conferences.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            return services;
        }
    }
}
