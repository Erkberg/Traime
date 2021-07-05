using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class DayWorktime : IEquatable<DayWorktime>
    {
        public int year;
        public int month;
        public int dayOfMonth;
        public string dayOfWeek;
        public List<ChunkWorktime> chunks;

        public DayWorktime()
        {
            DateTime date = DateTime.Today;
            year = date.Year;
            month = date.Month;
            dayOfMonth = date.Day;
            dayOfWeek = date.DayOfWeek.ToString();
            chunks = new List<ChunkWorktime>();
        }

        public void AddChunk(ChunkWorktime chunk)
        {
            chunks.Add(chunk);
        }

        public TimeOfDay GetDuration()
        {
            TimeOfDay duration = new TimeOfDay(DateTime.Today);

            foreach(ChunkWorktime chunk in chunks)
            {
                duration += chunk.GetDuration();
            }

            return duration;
        }

        public bool IsToday(DayWorktime day)
        {
            return day == new DayWorktime();
        }

        public bool Equals(DayWorktime other)
        {
            return this.year == other.year && this.dayOfMonth == other.dayOfMonth && this.dayOfMonth == other.dayOfMonth;
        }
    }
}