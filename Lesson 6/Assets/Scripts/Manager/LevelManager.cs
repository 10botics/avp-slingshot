using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelData levelToLoad;

        private void Start()
        {
            Instantiate(levelToLoad.levelPrefab, transform.position, Quaternion.identity, transform);
        }        
    }
}

