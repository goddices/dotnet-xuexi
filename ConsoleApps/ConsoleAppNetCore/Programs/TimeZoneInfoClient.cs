using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppNetCore.Programs
{
    public class TimeZoneInfoClient
    {
        public static void Run()
        {
            var tz = TimeZoneInfo.CreateCustomTimeZone("China Standard Time", TimeSpan.FromHours(8), "zhufeng time zone", "zhufeng time zone");
            var list = TimeZoneInfo.GetSystemTimeZones().AsEnumerable();


            /*
             
    "Id": "UTC-02",
    "DisplayName": "(UTC-02:00) 协调世界时-02",
    "StandardName": "UTC-02",
    "DaylightName": "UTC-02",
    "BaseUtcOffset": "-02:00:00",
             */
            var s = Newtonsoft.Json.JsonConvert.SerializeObject(list.Select(x => new
            {
                Id = x.Id,
                DisplayName = x.DisplayName,
                StandardName = x.StandardName,
                DaylightName = x.DaylightName,
                BaseUtcOffset = x.BaseUtcOffset
            }));
            foreach (TimeZoneInfo tzi in list)
            {
                Console.WriteLine(tzi);
            }

            foreach (var it in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(it.Id);
            }
        }
    }
}
