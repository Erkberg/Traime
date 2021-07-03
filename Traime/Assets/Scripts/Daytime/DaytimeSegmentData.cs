using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traime
{
    [System.Serializable]
    public class DaytimeSegmentData
    {
        public string text;
        public string startTime;
        public string endTime;

        public bool IsCurrentSegment()
        {
            DateTime startDateTime = DateTimeHelper.GetDateTimeForTimeString(startTime);
            DateTime endDateTime = DateTimeHelper.GetDateTimeForTimeString(endTime);

            return DateTimeHelper.IsDateTimeBetween(startDateTime, endDateTime);
        }
    }
}