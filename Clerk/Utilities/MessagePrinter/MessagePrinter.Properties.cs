using Clerk.Models;

namespace Clerk.Utilities
{
    public static partial class MessagePrinter
    {
        private static IMessageFormatter _messageFormatter
            = new MinorMessageFormatter();

        public static IMessageFormatter MessageFormatter
        {
            get => _messageFormatter;
            set => _messageFormatter = value;
        }
    }
}