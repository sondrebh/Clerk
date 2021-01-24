namespace Clerk.Models
{
    public sealed partial class LogFileManager : ILogFileManager
    {
        public string LogFilePrefix { get; set; } = "Log";
        public int LogFileMaxSizeInKB { get; set; } = 5000;
        public int LogFileMaxCount { get; set; } = 25;
        public bool FileLoggingEnabled { get; set; } = true;
    }
}