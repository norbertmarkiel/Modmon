using Modmon.Modules.Conferences.Api;
using Modmon.Shared.Infrastructure;

namespace Modmon.Bootstraper

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructure();
            builder.Services.AddConferences();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseInfrastructure();

            app.Run();
        }
    }
}
