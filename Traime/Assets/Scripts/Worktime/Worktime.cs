using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Traime
{
    public class Worktime : MonoBehaviour
    {
        public GameObject playButton;
        public GameObject stopButton;

        public TextMeshProUGUI timeChunkText;
        public TextMeshProUGUI timeTodayText;
        public TextMeshProUGUI timeWeekText;

        private bool isPlaying;
        
        private ChunkWorktime currentChunk;
        private DayWorktime currentDay;
        private WeekWorktime currentWeek;

        private void Awake()
        {
            currentDay = new DayWorktime();
            currentWeek = new WeekWorktime();
            currentWeek.AddDay(currentDay);
        }

        private void Update()
        {
            if(isPlaying)
            {
                timeChunkText.text = DateTimeHelper.GetTimeSpanStringHoursMinutesSeconds(currentChunk.GetTimeSpan());
                timeTodayText.text = DateTimeHelper.GetTimeSpanStringHoursMinutesSeconds(currentDay.GetTimeSpan());
                timeWeekText.text = DateTimeHelper.GetTimeSpanStringHoursMinutesSeconds(currentWeek.GetTimeSpan());
            }
        }

        public void OnPlayButtonPressed()
        {
            playButton.SetActive(false);
            stopButton.SetActive(true);

            currentChunk = new ChunkWorktime();
            currentChunk.Start();
            currentDay.AddChunk(currentChunk);

            isPlaying = true;
        }

        public void OnStopButtonPressed()
        {
            playButton.SetActive(true);
            stopButton.SetActive(false);

            currentChunk.End();

            isPlaying = false;
        }
    }
}