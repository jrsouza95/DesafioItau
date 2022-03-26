namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

/// <summary>
/// Base class to convert errors responses
/// </summary>
public abstract class ResponseError
{
    /// <summary>
    /// Error messages
    /// </summary>
    public string Errors { get; protected set; }

    /// <summary>
    /// Error stack trace
    /// </summary>
    public string StackTrace { get; protected set; }

    /// <summary>
    /// Response Http code
    /// </summary>
    public virtual int HttpCode { get; protected set; }

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="exception">Exception to be converted</param>
    public ResponseError(Exception exception)
    {
        Errors = exception.Message;
        StackTrace = exception.StackTrace;
    }
}