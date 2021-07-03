using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Traime
{
    public class Daytime : MonoBehaviour
    {
        public DaytimeSegmentsList segmentsList;
        public TextMeshProUGUI currentTimeText;
        public TextMeshProUGUI currentActivityText;
        public Image fillCurrentTime;
        public RectTransform segmentsHolder;
        public DayTimeSegment segmentPrefab;

        private List<DayTimeSegment> segments = new List<DayTimeSegment>();

        private IEnumerator Start()
        {
            yield return null;
            SpawnSegments();
        }

        private void SpawnSegments()
        {
            foreach (DaytimeSegmentData segmentData in segmentsList.segments)
            {
                DayTimeSegment segment = Instantiate(segmentPrefab, segmentsHolder);
                segment.InitFromData(segmentData, segmentsHolder.rect.width);
                segments.Add(segment);
            }
        }

        private void Update()
        {
            currentTimeText.text = DateTimeHelper.GetCurrentTimeString();            
            fillCurrentTime.fillAmount = DateTimeHelper.GetPercentageOfDayPassed();
            CheckCurrentSegment();
        }

        private void CheckCurrentSegment()
        {
            foreach (DayTimeSegment segment in segments)
            {
                if (segment.data.IsCurrentSegment())
                {
                    currentActivityText.text = segment.data.text;
                    segment.SetHighlighted(true);
                }
                else
                {
                    segment.SetHighlighted(false);
                }
            }
        }
    }
}