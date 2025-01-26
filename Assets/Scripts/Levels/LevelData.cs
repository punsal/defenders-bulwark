using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(menuName = "Create LevelData", fileName = "New LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private List<EnemySpawnData> enemySpawnData;
        public List<EnemySpawnData> EnemySpawnData => enemySpawnData;
    }
}