using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;

namespace DesafioItau.Infra.Tests._01_API.Exceptions;

public class ResponseInternalServerErrorTest
{
    [Test]
    public void ResponseInternalServerError_Should_Convert_Exception()
    {
        string exceptionMessage = "internal error test message";
        Exception exception = new(exceptionMessage);

        ResponseInternalServerError responseInternalServerError = new(exception);

        Assert.AreEqual("internal error test message", responseInternalServerError.Errors);
        Assert.AreEqual(StatusCodes.Status500InternalServerError, responseInternalServerError.HttpCode);
    }
}