using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class WeekWorktime
    {
        public List<DayWorktime> days = new List<DayWorktime>();

        public void AddDay(DayWorktime day)
        {
            days.Add(day);
        }

        public TimeSpan GetTimeSpan()
        {
            TimeSpan timeSpan = new TimeSpan();

            foreach (DayWorktime day in days)
            {
                timeSpan += day.GetTimeSpan();
            }

            return timeSpan;
        }
    }
}