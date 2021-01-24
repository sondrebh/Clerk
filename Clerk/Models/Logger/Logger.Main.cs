using Clerk.Models;
using Clerk.Utilities;

namespace Clerk
{
    public sealed partial class Logger : ILogger
    {
        public string Tag  { get; }

        public Logger(string tag)
        {
            this.Tag = tag;
        }

        private void formatAndPrintMessage(Message unFormatedMessage)
        {
            string formatedMessage = 
                MessagePrinter.MessageFormatter.FormatMessage(
                    unFormatedMessage
                );

            MessagePrinter.PrintMessage(formatedMessage);
            ClerkLog.LogFileManager.LogMessage(formatedMessage);
        }
    }
}