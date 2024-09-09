using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using Levels;
using System;
using Objects;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData levelToLoad;

        private LevelData playing;

        private void Awake()
        {
            LevelListTile.LevelSelected += LoadLevel;
            HitTarget.Destroyed += UpdateLevelStatus;

            Timer.TimerFired += GameOver;
            BallCounter.BallDepleted += GameOver;
        }

        private void GameOver()
        {
            HitTarget.Destroyed -= UpdateLevelStatus;
            Debug.Log("Game Over");
        }

        private void LoadLevel(LevelData levelData)
        {
            playing = levelData;
            Instantiate(playing.levelPrefab, transform.position, Quaternion.identity, transform);
        }

        public void Restart()
        {
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
                LoadLevel(playing);
            }
        }

        private void UpdateLevelStatus()
        {
            if (transform.GetChild(0).childCount == 1)
            {
                BallCounter.BallDepleted -= GameOver;
                Timer.TimerFired -= GameOver;
                Debug.Log("Level Completed");
            }
        }
    }
}

