using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Modmon.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        internal static WebApplicationBuilder ConfigureModules(this WebApplicationBuilder builder)
        {
            var env = builder.Environment;
            var config = builder.Configuration;

            foreach (var settings in GetSettings("*")) // Look for module.patterns.json
            {
                config.AddJsonFile(settings);
            }

            foreach (var settings in GetSettings($"*.{env.EnvironmentName}")) // Look for module.patterns.environment.json
            {
                config.AddJsonFile(settings);
            }

            return builder;

            IEnumerable<string> GetSettings(string pattern)
                => Directory.EnumerateFiles(env.ContentRootPath,
                    $"module.{pattern}.json", SearchOption.AllDirectories);
        }

        [Obsolete("Use ConfigureModules instead")]
        public static IHostBuilder ConfigureModuless(this IHostBuilder builder)
           => builder.ConfigureAppConfiguration((ctx, cfg) =>
       {
           foreach (var settings in GetSettings("*")) //look for module.patterns.json
           {
               cfg.AddJsonFile(settings); 
           }

           foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}")) //look for module.patterns.environment.json file (e.g. module.patterns.development.json)
           {
               cfg.AddJsonFile(settings);
           }

           IEnumerable<string> GetSettings(string pattern) 
               => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath, //For current directory
                   $"module.{pattern}.json", SearchOption.AllDirectories); //look for module.pattern.json in all subdirectories
       });
    }
}
