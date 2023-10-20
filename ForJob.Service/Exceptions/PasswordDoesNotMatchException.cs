namespace ForJob.Service.Exceptions;

public class PasswordDoesNotMatchException : Exception
{
    public PasswordDoesNotMatchException(string message) : base(message)
    {}

    public PasswordDoesNotMatchException(string message,Exception exception) : base(message, exception)
    {}
}
