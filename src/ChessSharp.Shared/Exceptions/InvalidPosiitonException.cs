namespace ChessSharp.Shared.Exceptions;

public class InvalidPositionException : Exception
{
    public InvalidPositionException()
    {
    }

    public InvalidPositionException(string? message) : base(message)
    {
    }

    public InvalidPositionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}