using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class SavedWorktime
    {
        public List<WeekWorktime> weeks;

        public SavedWorktime()
        {
            weeks = new List<WeekWorktime>();
        }

        public void UpdateWeek(WeekWorktime week)
        {
            if(weeks.Count == 0 || GetLatestWeek() != week)
            {
                weeks.Add(week);
            }
            else
            {
                weeks[weeks.Count - 1] = week;
            }
        }

        public WeekWorktime GetLatestWeek()
        {
            return weeks[weeks.Count - 1];
        }

        public DayWorktime GetLatestDay()
        {
            return GetLatestWeek().GetLatestDay();
        }
    }
}