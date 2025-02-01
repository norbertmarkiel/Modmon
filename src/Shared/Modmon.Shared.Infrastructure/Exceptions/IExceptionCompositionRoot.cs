using Modmon.Shared.Abstractions.Exceptions;

namespace Modmon.Shared.Infrastructure.Exceptions
{
    /// <summary>
    /// Checks the exceptionToResponseMapper from each module and checks if the exception has already been handled somewhere.
    /// Particularly useful if I wanted to change a modular monolith to a microservice, because each module should have its exceptionToResponseMapper. 
    /// All I need to do is add middleware in a specific module.
    /// </summary>
    internal interface IExceptionCompositionRoot //No one will use this mechanism implicitly, so I'm not putting it in the abstraction
    {
        ExceptionResponse Map(Exception exception);
    }
}