using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class WeekWorktime : IEquatable<WeekWorktime>
    {
        public int year;
        public int week;
        public List<DayWorktime> days;

        public WeekWorktime()
        {
            year = DateTime.Now.Year;
            week = GetCurrentWeek();

            days = new List<DayWorktime>();
        }

        public void AddDay(DayWorktime day)
        {
            days.Add(day);
        }

        public DayWorktime GetLatestDay()
        {
            return days[days.Count - 1];
        }

        private int GetCurrentWeek()
        {
            DateTime time = DateTime.Now;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public TimeOfDay GetDuration()
        {
            TimeOfDay duration = new TimeOfDay(DateTime.Today);

            foreach (DayWorktime day in days)
            {
                duration += day.GetDuration();
            }

            return duration;
        }

        public bool IsThisWeek(WeekWorktime week)
        {
            return week == new WeekWorktime();
        }

        public bool Equals(WeekWorktime other)
        {
            return (this.year == other.year && this.week == other.week);
        }
    }
}