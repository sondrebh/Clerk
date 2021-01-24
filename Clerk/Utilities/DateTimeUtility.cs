using System;

namespace Clerk.Utilities
{
    public static class DateTimeUtility
    {
        public static string GetDayMonthYear()
        {
            DateTime currentDate = DateTime.Now.Date;
            string dayMonthYear = currentDate.ToString("dd.MM.yyyy");
            return dayMonthYear;
        }

        public static string GetHourMinuteSecond()
        {
            DateTime currentDate = DateTime.Now;
            string hourMinuteSecond = currentDate.ToString("HH:mm:ss");
            return hourMinuteSecond;
        }
    }
}