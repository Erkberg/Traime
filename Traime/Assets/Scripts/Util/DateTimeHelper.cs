using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    public static class DateTimeHelper
    {
        private static System.Globalization.DateTimeFormatInfo dateTimeFormatInfo = System.Globalization.DateTimeFormatInfo.InvariantInfo;

        public static string GetCurrentTimeString()
        {
            return DateTime.Now.ToString("HH:mm", dateTimeFormatInfo);
        }

        public static float GetPercentageOfDayPassed()
        {
            return GetPercentageOfDayPassedForDateTimes(DateTime.Today, DateTime.Now);
        }

        public static float GetPercentageOfDayPassedForDateTimes(DateTime start, DateTime end)
        {
            TimeSpan timeSpan = end - start;
            return GetPercentageOfDayPassedForTimeSpan(timeSpan);
        }

        public static float GetPercentageOfDayPassedForTimeSpan(TimeSpan timeSpan)
        {
            float percentage = timeSpan.Hours / 24f + timeSpan.Minutes / 60f / 24f;

            return percentage;
        }

        public static DateTime GetDateTimeForTimeString(string timeString)
        {
            string[] split = timeString.Split(':');
            int hour = int.Parse(split[0]);
            int minute = int.Parse(split[1]);

            DateTime today = DateTime.Today;
            DateTime dateTime = new DateTime(today.Year, today.Month, today.Day, hour, minute, 0);

            return dateTime;
        }

        public static bool IsDateTimeBetween(DateTime start, DateTime end)
        {
            return DateTime.Now >= start && DateTime.Now < end;
        }

        
    }
}