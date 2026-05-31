using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texty.Tools.Date_Convertor
{
    internal static class DateConvertor
    {
        public static PersianDate GetPersianDate(DateTime gregorianDate)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            PersianDate persianDate = new PersianDate();

            persianDate.Date = gregorianDate;
           
            persianDate.Era = persianCalendar.GetEra(gregorianDate);

            persianDate.Year = persianCalendar.GetYear(gregorianDate);
            persianDate.MonthsInYear = persianCalendar.GetMonthsInYear(persianDate.Year, persianDate.Era);
            persianDate.DaysInYear = persianCalendar.GetDaysInYear(persianDate.Year, persianDate.Era);
            persianDate.DayOfYear = persianCalendar.GetDayOfYear(gregorianDate);

            persianDate.Month = persianCalendar.GetMonth(gregorianDate);
            persianDate.LeapMonth = persianCalendar.GetLeapMonth(persianDate.Year, persianDate.Era);
            persianDate.DaysInMonth = persianCalendar.GetDaysInMonth(persianDate.Year, persianDate.Month);

            persianDate.Day = persianCalendar.GetDayOfMonth(gregorianDate);
            persianDate.DayOfWeek = persianCalendar.GetDayOfWeek(gregorianDate);

            persianDate.Kind = gregorianDate.Kind;

            persianDate.Hour = persianCalendar.GetHour(gregorianDate);
            persianDate.Minute = persianCalendar.GetMinute(gregorianDate);
            persianDate.Second = persianCalendar.GetSecond(gregorianDate);
            persianDate.Miliseconds = persianCalendar.GetMilliseconds(gregorianDate);
            persianDate.Ticks = gregorianDate.Ticks;
            persianDate.TimeOfDay = gregorianDate.TimeOfDay;

            return persianDate;
        }

        public static DateTime GetGregorianDate(PersianDate persianDate)
        {
            DateTime gregorianDate = new DateTime(persianDate.Date.Year,
                                                  persianDate.Date.Month,
                                                  persianDate.Date.Day,
                                                  persianDate.Date.Hour,
                                                  persianDate.Date.Minute,
                                                  persianDate.Date.Second, 
                                                  persianDate.Date.Millisecond,
                                                  persianDate.Date.Kind);
            return gregorianDate;
        }
    }
}
