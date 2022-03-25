namespace DesafioItau.Domain.Exceptions;

public class InternalServerException : Exception
{
    public InternalServerException(string message, Exception exception)
    : base(message, exception)
    { }
}
