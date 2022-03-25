using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;

namespace DesafioItau.Infra.Tests._01_API.Exceptions;

public class ResponseBadRequestTest
{
    [Test]
    public void ResponseBadRequestTest_Should_Convert_Exception()
    {
        string exceptionMessage = "bad request error test message";
        Exception exception = new(exceptionMessage);

        ResponseBadRequest responseInternalServerError = new(exception);

        Assert.AreEqual("bad request error test message", responseInternalServerError.Errors);
        Assert.AreEqual(StatusCodes.Status400BadRequest, responseInternalServerError.HttpCode);
    }
}