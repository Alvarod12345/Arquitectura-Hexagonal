using CrossCutting.Utility.OxiServi.Constants;
using System;

namespace CrossCutting.Utility.OxiServi.Extensions
{
    public class DateExtensions
    {
        public static DateTime GetDate()
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(ApplicationConstants.TimeZone.Peru);
            DateTime cstTime = TimeZoneInfo.ConvertTime(DateTime.Now, cstZone);
            return cstTime;
        }

        public static long GenerateByCurrentDate()
        {
            long code = Convert.ToInt64(string.Concat(GetDate().ToString("yyyyMMddhhmmssfff"), 0));
            return code;
        }
        public  static DateTime GetMinValue()
        {
            return DateTime.ParseExact("01/01/1753","dd/MM/yyyy",null);
        }
    }
}
