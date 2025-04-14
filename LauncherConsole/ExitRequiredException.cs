
[Serializable]
internal class ExitRequiredException : Exception
{
    public ExitRequiredException()
    {
    }

    public ExitRequiredException(string? message) : base(message)
    {
    }

    public ExitRequiredException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}