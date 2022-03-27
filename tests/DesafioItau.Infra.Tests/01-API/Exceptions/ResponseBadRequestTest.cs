using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._01_API.Exceptions;

public class ResponseBadRequestTest
{
    [Test]
    public void ResponseBadRequestTest_Should_Convert_Exception()
    {
        string exceptionMessage = "bad request error test message";
        Exception exception = new(exceptionMessage);

        ResponseBadRequest responseInternalServerError = new(exception);

        responseInternalServerError.Errors.Should().Be("bad request error test message");
        responseInternalServerError.HttpCode.Should().Be(StatusCodes.Status400BadRequest);
    }
}