using Clerk.Utilities;

namespace Clerk
{
    public static partial class ClerkLog
    {
        private static MessageFormat _messageFormat
            = MessageFormat.Minor;

        public static MessageFormat MessageFormat
        { 
            get => _messageFormat;

            set {
                _messageFormat = value;
                MessagePrinter.MessageFormatter
                    = messageFormatterFactory.CreateMessageFormatter(value);
            }
        }
    }
}
