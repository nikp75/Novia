using System;

namespace Test.ExtensionMethods
{
    public static class DayOfWeekExtension
    {
        public static bool IsWeekend(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }
    }
}
