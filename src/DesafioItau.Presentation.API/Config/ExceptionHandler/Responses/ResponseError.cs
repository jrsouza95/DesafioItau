namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

public abstract class ResponseError
{
    public string Errors { get; protected set; }
    public string StackTrace { get; protected set; }
    public virtual int HttpCode { get; protected set; }

    public ResponseError(Exception exception)
    {
        Errors = exception.Message;
        StackTrace = exception.StackTrace;
    }
}