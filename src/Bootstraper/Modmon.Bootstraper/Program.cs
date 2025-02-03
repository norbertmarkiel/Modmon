using Modmon.Modules.Conferences.Api;
using Modmon.Shared.Infrastructure;

namespace Modmon.Bootstraper

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var _assemblies = ModuleLoader.LoadAssemblies();
            var _modules = ModuleLoader.LoadModules(_assemblies);

            // Add services to the container.
            builder.Services.AddInfrastructure(_modules);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseInfrastructure(_modules);

            _assemblies.Clear();
            _modules.Clear();
            

            app.Run();
        }
    }
}
