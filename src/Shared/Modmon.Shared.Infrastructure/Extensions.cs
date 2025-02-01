using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Shared.Abstractions;
using Modmon.Shared.Infrastructure.Api;
using Modmon.Shared.Infrastructure.Exceptions;
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
    }
}
