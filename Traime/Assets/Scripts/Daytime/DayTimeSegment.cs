using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Traime
{
    public class DayTimeSegment : MonoBehaviour
    {
        public RectTransform rectTransform;
        public TextMeshProUGUI text;
        public DaytimeSegmentData data;

        public List<Image> highlightImages;

        public void InitFromData(DaytimeSegmentData data, float segmentsTotalWidth)
        {
            this.data = data;

            text.text = data.text;

            Vector2 size = rectTransform.sizeDelta;
            size.x = GetWidthFromData(data, segmentsTotalWidth);
            rectTransform.sizeDelta = size;
        }

        private float GetWidthFromData(DaytimeSegmentData data, float segmentsTotalWidth)
        {
            DateTime start = DateTimeHelper.GetDateTimeForTimeString(data.startTime);
            DateTime end = DateTimeHelper.GetDateTimeForTimeString(data.endTime);

            float percentage = DateTimeHelper.GetPercentageOfDayPassedForDateTimes(start, end);

            return percentage * segmentsTotalWidth;
        }

        public void SetHighlighted(bool highlighted)
        {
            Color color = highlighted ? Game.inst.ui.colorPalette.highlightColor : Game.inst.ui.colorPalette.foregroundColor;
            text.color = color;

            foreach(Image highlightImage in highlightImages)
            {
                highlightImage.color = color;
            }
        }
    }
}