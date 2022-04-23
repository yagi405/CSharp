using System;

namespace ExtensionMethods.Demo
{
    public static class DateTimeExtensions
    {
        public static DateTime BeginOfMonth(this DateTime self)
        {
            return new DateTime(self.Year, self.Month, 1);
        }
    }
}
