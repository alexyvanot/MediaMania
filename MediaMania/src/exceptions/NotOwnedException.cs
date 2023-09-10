public class NotOwnedException : Exception
{
    public NotOwnedException(string? message) : base(message)
    {
    }
}