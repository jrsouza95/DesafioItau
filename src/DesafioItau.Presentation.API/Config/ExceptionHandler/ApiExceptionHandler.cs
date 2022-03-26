using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioItau.Presentation.API.Config.ExceptionHandler;

/// <summary>
/// Configures a filter to intercept an exception and treat it globally and return the request
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiExceptionHandler : ExceptionFilterAttribute, IFilterMetadata
{
    private readonly ILogger<ApiExceptionHandler> _logger;

    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="logger">Logger instance</param>
    public ApiExceptionHandler(ILogger<ApiExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Intercepts an exception and handles it before returning to the endpoint
    /// </summary>
    /// <param name="context">Exception context</param>
    public override void OnException(ExceptionContext context)
    {
        ResponseError obj;
        if (context.Exception is ArgumentNullException || context.Exception is ArgumentOutOfRangeException)
            obj = new ResponseBadRequest(context.Exception);

        else
            obj = new ResponseInternalServerError(context.Exception);
        
        BuildResponse(context, obj);

        _logger.LogError(context.Exception, "An error occurred while executing the request");
    }

    private void BuildResponse(ExceptionContext context, ResponseError obj)
    {
        context.HttpContext.Response.StatusCode = obj.HttpCode;
        context.Result = new JsonResult(obj);
    }
}