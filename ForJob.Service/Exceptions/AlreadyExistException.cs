using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ForJob.Service.Exceptions;

public class AlreadyExistException : Exception
{
    public int StatusCode = 401;
    public AlreadyExistException(string message) : base(message)
    {}
    public AlreadyExistException(string message, Exception exception) : base(message,exception)
    {}

}

