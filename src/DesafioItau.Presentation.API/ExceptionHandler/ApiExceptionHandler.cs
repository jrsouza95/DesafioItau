using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioItau.Presentation.API.ExceptionHandler;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiExceptionHandler : ExceptionFilterAttribute, IFilterMetadata
{
    private readonly ILogger _logger;

    public ApiExceptionHandler(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Intercepts an exception and handles it before returning to the endpoint
    /// </summary>
    /// <param name="context">Exception context</param>
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ArgumentNullException)
        {
            ResponseBadRequest obj = new(context.Exception);
            BuildResponse(context, obj);
        }

        else
        {
            ResponseInternalServerError obj = new(context.Exception);
            BuildResponse(context, obj);
        }

        _logger.LogError(context.Exception, "An error occurred while executing the request");
    }

    private void BuildResponse(ExceptionContext context, ResponseError obj)
    {
        context.HttpContext.Response.StatusCode = obj.HttpCode;
        context.Result = new JsonResult(obj);
    }
}