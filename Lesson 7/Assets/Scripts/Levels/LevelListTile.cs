using Objects;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Levels
{
    [RequireComponent(typeof(SpatialButton))]
    public class LevelListTile :MonoBehaviour
    {
        public LevelData LevelData { private get; set; }

        [SerializeField] private TMP_Text levelName;

        public int LevelIndex 
        {
            set => levelName.text = $"{value + 1}";
        }

        public delegate void LevelSelectedHandler(LevelData levelData);
        public static event LevelSelectedHandler LevelSelected;

        public void SelectLevel()
        {
            LevelSelected?.Invoke(LevelData);
        }
    }
}