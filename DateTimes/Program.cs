using System.Globalization;

namespace DateTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan nearlyTenDays = TimeSpan.FromDays(10) - TimeSpan.FromSeconds(1);

            Console.WriteLine(nearlyTenDays.Days);
            Console.WriteLine(nearlyTenDays.Hours);
            Console.WriteLine(nearlyTenDays.Minutes);
            Console.WriteLine(nearlyTenDays.Seconds);
            Console.WriteLine(nearlyTenDays.Milliseconds);

            Console.WriteLine(nearlyTenDays.TotalDays);
            Console.WriteLine(nearlyTenDays.TotalHours);
            Console.WriteLine(nearlyTenDays.TotalMinutes);
            Console.WriteLine(nearlyTenDays.TotalSeconds);
            Console.WriteLine(nearlyTenDays.TotalMilliseconds);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTimeOffset.Now);

            TimeZone zone = TimeZone.CurrentTimeZone;
            Console.WriteLine(zone.DaylightName);
            Console.WriteLine(zone.StandardName);


            DaylightTime day = zone.GetDaylightChanges(2021);
            Console.WriteLine(day.Start.ToString());
            Console.WriteLine(day.End.ToString());
            Console.WriteLine(day.Delta);
        }
    }
}
