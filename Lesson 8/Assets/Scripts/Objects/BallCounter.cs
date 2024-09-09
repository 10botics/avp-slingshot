using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Objects
{
    public class BallCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text counter;

        private int ballCount = 0;

        public delegate void BallDepletedHandler();
        public static event BallDepletedHandler BallDepleted;

        private void Awake()
        {
            LevelListTile.LevelSelected += SetCounter;
            Boulder.BoulderDestroyed += UpdateCounter;
        }

        private void UpdateCounter()
        {
            ballCount--;
            counter.text = ballCount.ToString();
            if (ballCount == 0)
            {
                BallDepleted?.Invoke();
            }
        }

        private void SetCounter(LevelData levelData)
        {
            ballCount = levelData.ballLimit;
            counter.text = ballCount.ToString();
        }
    }
}

