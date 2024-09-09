using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using Levels;
using System;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData levelToLoad;

        private LevelData playing;

        private void Awake()
        {
            LevelListTile.LevelSelected += LoadLevel;
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
    }
}

