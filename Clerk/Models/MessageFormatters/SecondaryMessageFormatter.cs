using Clerk.Utilities;

namespace Clerk.Models
{
    /*
        Example:

        [INFO] 11.07.2021 | 13:15:22 | MainActivity
        This is a message...
    */
    public sealed class SecondaryMessageFormatter : IMessageFormatter
    {
        public string FormatMessage(Message unFormatedMessage)
        {
            (string prefix, string unFormatedRawMessage, string tag) = unFormatedMessage;

            string dayMonthYear = DateTimeUtility.GetDayMonthYear();
            string hourMinuteSecond = DateTimeUtility.GetHourMinuteSecond();

            string formatedMessage = 
                $"[{prefix}] {dayMonthYear} | {hourMinuteSecond} | {tag}\n{unFormatedRawMessage}\n";

            return formatedMessage;
        }
    }
}