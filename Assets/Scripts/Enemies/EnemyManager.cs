using System;
using System.Collections.Generic;
using Abstract;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    
    public class EnemyManager : AGameBehaviour
    {
        [SerializeField] private float spawnRadius = 10f;

        private Dictionary<EnemySpawnData, bool> _data;
        
        private List<Enemy> _spawnedEnemies;

        protected override void OnEnable()
        {
            base.OnEnable();
            Game.Events.Destroyed += OnDestroyed;
        }

        private void OnDestroy()
        {
            Game.Events.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed(Enemy obj)
        {
            if (_spawnedEnemies !=null && _spawnedEnemies.Count > 0)
            {
                _spawnedEnemies.Remove(obj);
            }
        }

        public void Initialize(List<EnemySpawnData> spawnData)
        {
            _data = new Dictionary<EnemySpawnData, bool>();
            _spawnedEnemies = new List<Enemy>();
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
            var completedKeys = new List<EnemySpawnData>();
            var enemySpawnData = _data.Keys;
            foreach (var spawnData in enemySpawnData)
            {
                if (spawnData.Amount < 1)
                {
                    completedKeys.Add(spawnData);
                    continue;
                }
                
                spawnData.AddTime(Time.deltaTime);
                if (!(spawnData.Timer >= spawnData.TimeBetweenSpawns))
                {
                    continue;
                }

                var enemy = Spawn(spawnData.EnemyData.Prefab);
                enemy.Initialize(spawnData.EnemyData.MovementSpeed);
                _spawnedEnemies.Add(enemy);
                spawnData.EnemySpawned();
                spawnData.ResetTimer();
            }

            foreach (var key in completedKeys)
            {
                _data[key] = true;
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
                if (_spawnedEnemies.Count > 0)
                {
                    return;
                }
                Game.Events.OnWaveCompleted();
            }
        }
    }
}