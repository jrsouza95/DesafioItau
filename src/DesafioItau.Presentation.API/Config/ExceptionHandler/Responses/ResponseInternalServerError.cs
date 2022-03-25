namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

/// <summary>
/// Converts an exception to default internal server error response
/// </summary>
public class ResponseInternalServerError : ResponseError
{
    /// <summary>
    /// Internal Server Error status code: 500
    /// </summary>
    public override int HttpCode => StatusCodes.Status500InternalServerError;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="exception">Exception to be converted</param>
    public ResponseInternalServerError(Exception exception) 
        : base(exception) { }
}
