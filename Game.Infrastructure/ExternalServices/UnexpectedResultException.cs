namespace Game.Infrastructure.ExternalServices;

public class UnexpectedResultException: Exception
{
    public UnexpectedResultException(string message) : base(message)
    {
    }
}
