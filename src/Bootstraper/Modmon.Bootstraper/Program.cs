namespace Modmon.Bootstraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapControllers();
            app.MapGet("/", async context => await context.Response.WriteAsync("Hello Modmon World!"));

            app.Run();
        }
    }
}
