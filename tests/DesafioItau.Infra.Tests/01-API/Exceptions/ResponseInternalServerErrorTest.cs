using DesafioItau.Presentation.API.ExceptionHandler.Responses;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace DesafioItau.Infra.Tests._01_API.Exceptions;

public class ResponseInternalServerErrorTest
{
    [Test]
    public void ResponseInternalServerError_Should_Convert_Exception()
    {
        string exceptionMessage = "internal error test message";
        Exception exception = new(exceptionMessage);

        ResponseInternalServerError responseInternalServerError = new(exception);

        responseInternalServerError.Errors.Should().Be("internal error test message");
        responseInternalServerError.HttpCode.Should().Be(StatusCodes.Status500InternalServerError);
    }
}