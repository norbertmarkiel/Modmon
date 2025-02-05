using Modmon.Modules.Conferences.Api;
using Modmon.Shared.Infrastructure;
using Modmon.Shared.Infrastructure.Modules;

namespace Modmon.Bootstraper

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigureModules();


            var _assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
            var _modules = ModuleLoader.LoadModules(_assemblies);

            // Add services to the container.
            builder.Services.AddInfrastructure(_assemblies, _modules);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseInfrastructure(_modules);

            _assemblies.Clear();
            _modules.Clear();
            

            app.Run();
        }
    }
}
