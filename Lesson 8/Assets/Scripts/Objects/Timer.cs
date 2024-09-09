using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using Manager;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Objects
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        private float remainingTime = 0f;


        private IEnumerator timerCoroutine;
        public delegate void TimerFireHandler();
        public static event TimerFireHandler TimerFired;

        private void Awake()
        {
            timerCoroutine = TimerCoroutine();

            LevelListTile.LevelSelected += StartTimer;
        }

        private void StartTimer(LevelData levelData)
        {
            remainingTime = levelData.timeLimit;
            StartCoroutine(timerCoroutine);
        }

        private IEnumerator TimerCoroutine()
        {
            while (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                timerText.text = remainingTime.ToString("F2");
                yield return null;
            }
            timerText.text = "0.00";
            TimerFired?.Invoke();
        }
    }
}

