using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Traime
{
    public class Timer : MonoBehaviour
    {
        public GameObject playButton;
        public GameObject stopButton;
        public AudioSource audioSource;
        public int minutes;
        public TextMeshProUGUI passedText;
        public TextMeshProUGUI totalText;

        private TimeOfDay timerTotal;
        private TimeOfDay timerPassed;
        private TimeOfDay timerStarted;
        private bool isPlaying;

        private void Awake() 
        {
            timerTotal = new TimeOfDay(0, minutes, 0);
            totalText.text = $"{minutes}:00";
        }

        private void Update() 
        {
            if(isPlaying)
            {
                timerPassed = new TimeOfDay(DateTime.Now) - timerStarted;
                passedText.text = timerPassed.ToString();

                if(timerPassed > timerTotal)
                {
                    OnTimer();
                }
            }
        }

        private void OnTimer()
        {
            audioSource.Play();
            timerStarted = new TimeOfDay(DateTime.Now);
        }

        public void OnPlayButtonPressed()
        {
            playButton.SetActive(false);
            stopButton.SetActive(true);
            timerStarted = new TimeOfDay(DateTime.Now);

            isPlaying = true;
        }

        public void OnStopButtonPressed()
        {
            playButton.SetActive(true);
            stopButton.SetActive(false);

            isPlaying = false;
        }
    }
}