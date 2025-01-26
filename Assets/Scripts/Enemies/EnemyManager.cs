using System.Collections.Generic;
using Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyManager : AGameBehaviour
    {
        [SerializeField] private float spawnRadius = 10f;

        private Dictionary<EnemySpawnData, bool> _data;
        
        public void Initialize(List<EnemySpawnData> spawnData)
        {
            _data = new Dictionary<EnemySpawnData, bool>();
            foreach (var data in spawnData)
            {
                _data.Add(data, false);
            }
        }

        private Enemy Spawn(Enemy prefab) 
        { 
            var angle = Random.Range(0f, 360f);
            var spawnPosition = spawnRadius * new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad));
            return Instantiate(prefab, spawnPosition, Quaternion.identity);
        }

        protected override void OnUpdate()
        {
            var enemySpawnData = _data.Keys;
            foreach (var spawnData in enemySpawnData)
            {
                if (spawnData.Amount < 1)
                {
                    _data[spawnData] = true;
                    continue;
                }
                
                spawnData.AddTime(Time.deltaTime);
                if (!(spawnData.Timer >= spawnData.TimeBetweenSpawns))
                {
                    continue;
                }

                var enemy = Spawn(spawnData.EnemyData.Prefab);
                enemy.Initialize(spawnData.EnemyData.MovementSpeed);
                spawnData.EnemySpawned();
                spawnData.ResetTimer();
            }
            
            var values = _data.Values;
            var isComplete = true;
            foreach (var value in values)
            {
                if (value == false)
                {
                    isComplete = false;
                    break;
                }
            }

            if (isComplete)
            {
                Game.Events.OnWaveCompleted();
            }
        }
    }
}