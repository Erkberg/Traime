using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class TimeOfDay
    {
        public int hour;
        public int minute;
        public int second;

        public TimeOfDay(DateTime dateTime)
        {
            hour = dateTime.Hour;
            minute = dateTime.Minute;
            second = dateTime.Second;
        }

        public TimeOfDay(int h, int m, int s)
        {
            hour = h;
            minute = m;
            second = s;
        }

        public static TimeOfDay operator +(TimeOfDay tod1, TimeOfDay tod2) 
        {
            int hour = tod1.hour + tod2.hour;
            int minute = tod1.minute + tod2.minute;
            int second = tod1.second + tod2.second;
            
            if(second > 60)
            {
                minute++;
                second -= 60;
            }

            if(minute > 60)
            {
                hour++;
                minute -= 60;
            }

            return new TimeOfDay(hour, minute, second);
        }

        public static TimeOfDay operator -(TimeOfDay tod1, TimeOfDay tod2) 
        {
            int hour = tod1.hour - tod2.hour;
            int minute = tod1.minute - tod2.minute;
            int second = tod1.second - tod2.second;

            if(second < 0)
            {
                minute--;
                second += 60;
            }

            if(minute < 0)
            {
                hour--;
                minute += 60;
            }

            return new TimeOfDay(hour, minute, second);
        }

        public static bool operator <(TimeOfDay tod1, TimeOfDay tod2) 
        {
            return (tod1.hour < tod2.hour) || (tod1.hour == tod2.hour && tod1.minute < tod2.minute) || 
                    (tod1.hour == tod2.hour && tod1.minute == tod2.minute && tod1.second < tod2.second);
        }

        public static bool operator >(TimeOfDay tod1, TimeOfDay tod2) 
        {
            return (tod1.hour > tod2.hour) || (tod1.hour == tod2.hour && tod1.minute > tod2.minute) || 
                    (tod1.hour == tod2.hour && tod1.minute == tod2.minute && tod1.second > tod2.second);
        }

        public override string ToString()
        {
            string hourString = hour.ToString();
            string minuteString = minute < 10 ? $"0{minute.ToString()}" : minute.ToString();
            string secondString = second < 10 ? $"0{second.ToString()}" : second.ToString();

            return $"{hourString}:{minuteString}:{secondString}";
        }
    }
}