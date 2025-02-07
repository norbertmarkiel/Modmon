using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Modmon.Shared.Abstractions.Modules
{
    public interface IModule
    {
        string Name { get; }
        string Path { get; }
        IEnumerable<string> Policies => null;
        void Register(IServiceCollection sercices);
        void Use(IApplicationBuilder app);
    }
}
