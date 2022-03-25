namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

public class ResponseInternalServerError : ResponseError
{
    public override int HttpCode => StatusCodes.Status500InternalServerError;

    public ResponseInternalServerError(Exception exception) 
        : base(exception) { }
}
