namespace DesafioItau.Presentation.API.ExceptionHandler.Responses;

public class ResponseBadRequest : ResponseError
{
    public override int HttpCode => StatusCodes.Status400BadRequest;

    public ResponseBadRequest(Exception exception)
        : base(exception) { }
}