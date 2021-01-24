using System;

namespace Clerk.Models
{
    public class MessageFormatterFactory : IMessageFormatterFactory
    {
        public IMessageFormatter CreateMessageFormatter(MessageFormat messageFormat)
            => messageFormat switch {
                MessageFormat.Minor     => new MinorMessageFormatter(),
                MessageFormat.Secondary => new SecondaryMessageFormatter(),
                MessageFormat.Major     => new MajorMessageFormatter(),
                _                       => throw new ArgumentOutOfRangeException(nameof(messageFormat)),
            };
    }
}