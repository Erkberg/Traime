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

        private SavedWorktime savedWorktime;

        private const string SaveName = "/save.json";

        private void Awake()
        {
            Load();
            UpdateUI();
        }

        private void Update()
        {
            if(isPlaying)
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            if(currentChunk != null)
                timeChunkText.text = currentChunk.GetDuration().ToString();
                
            timeTodayText.text = currentDay.GetDuration().ToString();
            timeWeekText.text = currentWeek.GetDuration().ToString();
        }

        public void OnPlayButtonPressed()
        {
            playButton.SetActive(false);
            stopButton.SetActive(true);

            currentChunk = new ChunkWorktime(currentDay.chunks.Count);
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

            Save();
        }

        private void OnDestroy() 
        {
            Save();
        }

        private void Save()
        {
            savedWorktime.UpdateWeek(currentWeek);
            string json = JsonUtility.ToJson(savedWorktime);
            FileUtil.WriteFileText(SaveName, json);
        }

        private void Load()
        {
            if(!FileUtil.FileExists(SaveName))
            {
                savedWorktime = new SavedWorktime();

                currentDay = new DayWorktime();
                currentWeek = new WeekWorktime();
                currentWeek.AddDay(currentDay);
            }
            else
            {
                string json = FileUtil.ReadFileText(SaveName);
                savedWorktime = JsonUtility.FromJson<SavedWorktime>(json);
                currentWeek = savedWorktime.GetLatestWeek();
                currentDay = savedWorktime.GetLatestDay();                
                CheckNewWeek();
                CheckNewDay();
            }
        }

        private void CheckNewWeek()
        {
            WeekWorktime newWeek = new WeekWorktime();
            if(!currentWeek.Equals(newWeek))
            {
                currentWeek = newWeek;
                savedWorktime.weeks.Add(currentWeek);
            }
        }

        private void CheckNewDay()
        {
            DayWorktime newDay = new DayWorktime();
            if(!currentDay.Equals(newDay))
            {
                currentDay = newDay;
                currentWeek.AddDay(currentDay);
            }
        }
    }
}