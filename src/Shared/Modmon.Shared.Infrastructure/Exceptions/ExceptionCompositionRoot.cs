using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Shared.Infrastructure.Exceptions
{
    internal class ExceptionCompositionRoot : IExceptionCompositionRoot
    {
        private readonly IServiceProvider _serviceProvider;

        public ExceptionCompositionRoot(IServiceProvider serviceProvider) //Generally inject IServiceProvider is antiPattern.
        {
            _serviceProvider = serviceProvider;
        }

        public ExceptionResponse Map(Exception exception)
        {
            using var scope = _serviceProvider.CreateScope();
            var mappers = scope.ServiceProvider.GetServices<IExceptionToResponseMapper>().ToArray(); //return all mappers from all services
            var nonDefaultMappers = mappers.Where(x => x is not ExceptionToResponseMapper);  
            var result = nonDefaultMappers
                .Select(x => x.Map(exception))
                .SingleOrDefault(x => x is not null);

            if (result is not null)
            {
                return result; // return finded mapper
            }

            var defaultMapper = mappers.SingleOrDefault(x => x is ExceptionToResponseMapper); //Fallback to default mapper

            return defaultMapper?.Map(exception);
        }
    }
}
