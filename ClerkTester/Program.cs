using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Clerk;

namespace ClerkTester
{
    class Program
    {
        private static Logger log = ClerkLog.GetLogger("Program");

        static void Main(string[] args)
        {
            initializeClerk();

            log.Info("Starting.");
            log.Error("Could not find specified file at index.");
            log.Warn("Yo!");
        }

        private static void initializeClerk()
        {
            ClerkLog.LogFileManager.FileLoggingEnabled = true;
            ClerkLog.MessageFormat = MessageFormat.Minor;
        }
    }
}
