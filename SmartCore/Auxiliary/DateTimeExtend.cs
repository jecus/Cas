using System;
using System.Collections.Generic;
using SmartCore.Calculations;

namespace SmartCore.Auxiliary
{
    public static class DateTimeExtend
    {
        public static DateTime AddCalendarSpan(this DateTime dateTime, CalendarSpan calendarSpan)
        {
            if(calendarSpan == null)
                return new DateTime(dateTime.Ticks);

            DateTime result;
            switch (calendarSpan.CalendarType)
            {
                case CalendarTypes.Days:
                    result = dateTime.AddDays(System.Convert.ToDouble(calendarSpan.CalendarValue));
                    break;
                case CalendarTypes.Months:
                    result = dateTime.AddMonths(System.Convert.ToInt32(calendarSpan.CalendarValue));
                    break;
                case CalendarTypes.Years:
                    result = dateTime.AddYears(System.Convert.ToInt32(calendarSpan.CalendarValue));
                    break;
                default:
                    result = new DateTime(dateTime.Ticks);
                    break;
            }

            return result;
        }

	    public static DateTimeDiff DifferenceDateTime(this DateTime d1, DateTime d2)
	    {
		    return new DateTimeDiff(d1,d2);
	    }

		public static DateTime GetCASMinDateTime()
		{
			return new DateTime(1950, 1, 1);
		}

	    public static IEnumerable<DateTime> AllDatesBetween(DateTime start, DateTime end)
	    {
		    for (var day = start.Date; day <= end; day = day.AddDays(1))
			    yield return day;
	    }

	}
}
