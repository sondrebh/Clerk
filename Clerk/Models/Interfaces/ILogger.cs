namespace Clerk.Models
{
    public interface ILogger 
    {
        string Tag { get; }
        void Info<T> (T rawMessage);
        void Debug<T> (T rawMessage);
        void Warn<T> (T rawMessage);
        void Error<T> (T rawMessage);
        void Fatal<T> (T rawMessage);
    }
}