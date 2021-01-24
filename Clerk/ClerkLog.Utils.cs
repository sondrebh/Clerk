using Clerk.Models;

namespace Clerk
{
    public static partial class ClerkLog
    {
        public static Logger GetLogger(string tag)
            => new Logger(tag);
    }
}
