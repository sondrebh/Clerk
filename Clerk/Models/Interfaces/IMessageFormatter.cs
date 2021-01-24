namespace Clerk.Models
{
    public interface IMessageFormatter
    {
        string FormatMessage(Message unFormatedMessage);
    }
}