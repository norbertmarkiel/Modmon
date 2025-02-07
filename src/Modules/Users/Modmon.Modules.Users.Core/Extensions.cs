using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Modules.Users.Core.DAL;
using Modmon.Modules.Users.Core.DAL.Repositories;
using Modmon.Modules.Users.Core.Entities;
using Modmon.Modules.Users.Core.Repositories;
using Modmon.Modules.Users.Core.Services;
using Modmon.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Modmon.Modules.Users.Api")]
namespace Modmon.Modules.Users.Core
{
    internal static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<IUserRepository, UserRepository>()
                .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddPostgres<UsersDbContext>();
    }
}
