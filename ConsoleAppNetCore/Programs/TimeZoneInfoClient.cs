using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppNetCore.Programs
{
    public class TimeZoneInfoClient
    {
        public static void Run()
        {
            var list = TimeZoneInfo.GetSystemTimeZones();

            foreach (TimeZoneInfo tzi in list)
            {
                Console.WriteLine(tzi);
            }
        }
    }
}
