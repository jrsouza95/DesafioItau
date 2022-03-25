namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

/// <summary>
/// Converts an exception to default Bad Request response
/// </summary>
public class ResponseBadRequest : ResponseError
{
    /// <summary>
    /// Bad Request status code: 400
    /// </summary>
    public override int HttpCode => StatusCodes.Status400BadRequest;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="exception">Exception to be converted</param>
    public ResponseBadRequest(Exception exception)
        : base(exception) { }
}