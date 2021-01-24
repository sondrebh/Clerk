namespace Clerk.Models
{
    public interface ILogFileManager
    {
        void LogMessage(string message);
        string LogFilePrefix { get; set; }
        int LogFileMaxSizeInKB { get; set; }
        int LogFileMaxCount { get; set; }
    }
}