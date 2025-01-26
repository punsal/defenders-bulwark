using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<LevelData> levels;

        public LevelData GetLevel()
        {
            foreach (var spawnData in levels.SelectMany(level => level.EnemySpawnData))
            {
                spawnData.Initialize();
            }
            
            var rng = Random.Range(0, levels.Count);
            return levels[rng];
        }
    }
}
