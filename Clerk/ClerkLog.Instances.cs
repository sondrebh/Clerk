using Clerk.Models;

namespace Clerk
{
    public static partial class ClerkLog
    {
        private static MessageFormatterFactory messageFormatterFactory
            = new MessageFormatterFactory();
        public static LogFileManager LogFileManager
                    = new LogFileManager();
    }
}
