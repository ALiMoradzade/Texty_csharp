using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Texty.Tools.Date_Convertor
{
    internal class PersianDate
    {
        public DateTime Date { get; internal set; } = DateTime.MinValue;
        public int Era { get; internal set; }

        public int Year { get; internal set; }
        public int MonthsInYear { get; internal set; }
        public int DaysInYear { get; internal set; }
        public int DayOfYear { get; internal set; }

        public int Month { get; internal set; }
        public int LeapMonth { get; internal set; }
        public int DaysInMonth { get; internal set; }

        public int Day { get; internal set; }
        public DayOfWeek DayOfWeek { get; internal set; } = DayOfWeek.Saturday;
        public TimeSpan TimeOfDay { get; internal set; }

        public DateTimeKind Kind { get; internal set; }

        public int Hour { get; internal set; }
        public int Minute { get; internal set; }
        public int Second { get; internal set; }
        public double Miliseconds { get; internal set; }
        public long Ticks { get; internal set; }

        public PersianDate()
        {
        }

        public PersianDate(int solarHijriYear, int solarHijriMonth, int solarHijriDay, int solarHijriHour,int solarHijriMinute,int solarHijriSecond,int solarHijriMillisecond)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDateTime = persianCalendar.ToDateTime(solarHijriYear,
                                                                    solarHijriMonth,
                                                                    solarHijriDay, 
                                                                    solarHijriHour, 
                                                                    solarHijriMinute,
                                                                    solarHijriSecond,
                                                                    solarHijriMillisecond);

            PersianDate persianDate = DateConvertor.GetPersianDate(gregorianDateTime);
            Date = persianDate.Date;
            Era = persianDate.Era;

            Year = persianDate.Year;
            MonthsInYear = persianDate.MonthsInYear;
            DaysInYear = persianDate.DaysInYear;
            DayOfYear = persianDate.DayOfYear;

            Month = persianDate.Month;
            LeapMonth = persianDate.LeapMonth;
            DaysInMonth = persianDate.DaysInMonth;

            Day = persianDate.Day;
            DayOfWeek = persianDate.DayOfWeek;
            TimeOfDay = persianDate.TimeOfDay;

            Kind = persianDate.Kind;

            Hour = persianDate.Hour;
            Minute = persianDate.Minute;
            Second = persianDate.Second;
            Miliseconds = persianDate.Miliseconds;
            Ticks = persianDate.Ticks;
        }

        public PersianDate(int solarHijriYear, int solarHijriMonth, int solarHijriDay, int solarHijriHour, int solarHijriMinute, int solarHijriSecond, int solarHijriMillisecond, int solarHijriEra)
                    : this(solarHijriYear, solarHijriMonth, solarHijriDay, solarHijriHour, solarHijriMinute, solarHijriSecond, solarHijriMillisecond)
        {
            Era = solarHijriEra;
        }

        public override string ToString()
        {
            return $"{Day:00}/{Month:00}/{Year:0000} {Date:hh:mm:ss tt}";
        }
    }
}
