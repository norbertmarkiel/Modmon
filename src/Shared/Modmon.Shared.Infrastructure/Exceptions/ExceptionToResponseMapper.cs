using Humanizer;
using Modmon.Shared.Abstractions.Exceptions;
using System.Collections.Concurrent;
using System.Net;

namespace Modmon.Shared.Infrastructure.Exceptions
{
    internal class ExceptionToResponseMapper : IExceptionToResponseMapper
    {

        private static readonly ConcurrentDictionary<Type, string> Codes = new();

        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                ModmonException ex =>
                    new ExceptionResponse(
                        new ErrorsResponse(
                            new Error(GetErrorCode(ex), ex.Message))
                    , HttpStatusCode.BadRequest),

                _ => new ExceptionResponse(new ErrorsResponse(new Error("Error", "There was as error.")), 
                    HttpStatusCode.InternalServerError)
            };
        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return Codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
        }


        /// <summary>
        /// Represents API reponse with errors returned to the user.
        /// </summary>
        private record ErrorsResponse(params Error[] Errors);

        /// <summary>
        /// Represents error returned to the user
        /// </summary>
        private record Error(string Code, string Message);


    }
}
