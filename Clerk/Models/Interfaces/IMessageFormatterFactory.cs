namespace Clerk.Models
{
    public interface IMessageFormatterFactory
    {
        IMessageFormatter CreateMessageFormatter(MessageFormat messageFormat);
    }
}