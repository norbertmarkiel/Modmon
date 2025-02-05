using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Modmon.Shared.Abstractions;
using Modmon.Shared.Abstractions.Modules;
using Modmon.Shared.Infrastructure.Api;
using Modmon.Shared.Infrastructure.Exceptions;
using Modmon.Shared.Infrastructure.Services;
using Modmon.Shared.Infrastructure.Time;
using System.Reflection;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Modmon.Bootstraper")]
namespace Modmon.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IList<Assembly> _assemblies, IList<IModule> _modules)
        {
            var disabledModules = new List<string>();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                        continue;

                    if (!bool.Parse(value))
                        disabledModules.Add(key.Split(":")[0]);
                }
            }


            foreach (var item in _modules)
            {
                item.Register(services);
            }

            services.AddErrorHandling();
            services.AddSingleton<IClock, Clock>();
            services.AddHostedService<AppInitializer>();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager => //For loading internal controllers from modules
                {
                    var removedParts = new List<ApplicationPart>();
                    foreach (var disabledModule in disabledModules)
                    {
                        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule, StringComparison.InvariantCultureIgnoreCase));
                        removedParts.AddRange(parts);

                        foreach (var part in removedParts)
                        {
                            manager.ApplicationParts.Remove(part); //remove disabled modules
                        }
                    }
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IList<IModule> _modules)
        {
            app.UseErrorHandling(); // It's important to add ExceptionHandler as first using. The order of Use in ApplicationBuilder matters.

            app.UseRouting();


            foreach (var item in _modules)
            {
                item.Use(app);
            }

            //TODO log installed modules


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World from Modmon!");
                });
            });


            return app;
        }
        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider(); //!!Can be dangerous. It's workaround to avoid passing IServiceCollection to every serivce.
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;

        }

    }
}


//Iconfiguration przekazywanie wszedzie przez caly czas trwania boostraptu -> jest bezpieczniejsy

//TworzyInstancje - . problem kazdorwazowe serivce providera builduje zaleznosci, co moze byc problematyczne w przypadku singletonów.


//Kod ktory wywoluje sie tyle ile razy robi sie build Service probider-> mozna to zabezpieczac, albo poswiecic cleanCode na rzecz bezpieczenstwa i wydajnosci i byc pewnym ze jest to czystsze.