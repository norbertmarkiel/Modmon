using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Shared.Abstractions;
using Modmon.Shared.Infrastructure.Api;
using Modmon.Shared.Infrastructure.Exceptions;
using Modmon.Shared.Infrastructure.Services;
using Modmon.Shared.Infrastructure.Time;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Modmon.Bootstraper")]
namespace Modmon.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddErrorHandling();
            services.AddSingleton<IClock, Clock>();
            services.AddHostedService<AppInitializer>();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager => //For loading internal controllers from modules
                { 
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                }); 

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandling(); // It's important to add ExceptionHandler as first using. The order of Use in ApplicationBuilder matters.

            app.UseRouting();

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