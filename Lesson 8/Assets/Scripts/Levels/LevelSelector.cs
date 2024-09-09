using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Unity.Mathematics;
using UnityEngine;

namespace Levels
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Transform levelTile;
        [SerializeField] private LevelData[] levels;

        private void Awake()
        {
            LevelListTile.LevelSelected += DisableUI;
        }

        private void Start()
        {
            for (var i = 0; i < levels.Length; i++)
            {
                var tile = Instantiate(levelTile, transform);
                
                tile.localPosition = grid.GetCellCenterLocal(new Vector3Int(i % 5, -i / 5, 0)) - 
                    (Vector3)(grid.GetLayoutCellCenter() * new float3(1, 1, 0));

                var levelListTile = tile.GetComponent<LevelListTile>();
                levelListTile.LevelData = levels[i];
                levelListTile.LevelIndex = i;
            }
        }

        private void DisableUI(LevelData _)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}

