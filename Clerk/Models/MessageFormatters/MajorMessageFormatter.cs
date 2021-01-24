using Clerk.Utilities;

namespace Clerk.Models 
{
    /*
        Example:

        [INFO] 11.07.2021 | 13:15:22 | MainActivity
        -----------------------------------
        This is a message...
    */
    public sealed class MajorMessageFormatter : IMessageFormatter
    {
        public string FormatMessage(Message unFormatedMessage)
        {
            (string prefix, string unFormatedRawMessage, string tag) = unFormatedMessage;

            string dayMonthYear = DateTimeUtility.GetDayMonthYear();
            string hourMinuteSecond = DateTimeUtility.GetHourMinuteSecond();

            string infoLine = 
                $"[{prefix}] {dayMonthYear} | {hourMinuteSecond} | {tag}";

            string breakLine = getBreakLine(infoLine.Length);

            string formatedMessage =
                $"{infoLine}\n{breakLine}\n{unFormatedRawMessage}\n";

            return formatedMessage;
        }

        private string getBreakLine(int length)
        {
            string breakLineChar = "-";
            
            string breakLine = "";

            for(int i = 0; i < length; i++)
                breakLine += breakLineChar;

            return breakLine;
        }
    }
}