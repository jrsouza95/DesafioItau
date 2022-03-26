using DesafioItau.Domain.Exceptions;
using NUnit.Framework;
using System;

namespace DesafioItau.Infra.Tests._03_Domain.Exceptions;

public class InternalServerExceptionTest
{
    [Test]
    public void InternalServerException_Constructor_Should_Assign_Correctly_Values()
    {
        Exception ex = new("ex base message");
        string message = "internal exception message";

        InternalServerException internalServerException = new(message, ex);

        Assert.AreEqual(message, internalServerException.Message);
        Assert.AreEqual(ex, internalServerException.InnerException);
    }

    [Test]
    public void InternalServerException_Should_Throw_Correctly()
    {
        Exception ex = new("ex base message");
        string message = "internal exception message";

        var throws = Assert.Throws<InternalServerException>(() => throw new InternalServerException(message, ex));

        Assert.AreEqual(message, throws.Message);
        Assert.AreEqual(ex, throws.InnerException);
    }
}