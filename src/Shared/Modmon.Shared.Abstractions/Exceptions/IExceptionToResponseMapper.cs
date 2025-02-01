namespace Modmon.Shared.Abstractions.Exceptions
{
    /// <summary>
    /// If exception inherits from ModmonException then pass message plus code. If exception is not in the list then pass InternalServerError (don't pass more information than needed)
    /// </summary>
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}
