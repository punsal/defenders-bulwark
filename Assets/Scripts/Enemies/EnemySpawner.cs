using System.Collections.Generic;
using Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawner : AGameBehaviour
    {
        [SerializeField] private List<Enemy> enemyPrefabs;
        [SerializeField] private bool isRandom;
        [SerializeField] private Enemy prefab;
        [SerializeField] private float spawnRadius = 10f;
    
        [SerializeField] private float timeBetweenSpawns;
        private float _timeSinceLastSpawn = 0f;

        private int _count;
        
        private void Start()
        {
            _count = enemyPrefabs.Count;
        }

        private void Spawn() 
        { 
            var randomIndex = Random.Range(0, _count);
            var randomPrefab = enemyPrefabs[randomIndex];
            var angle = Random.Range(0f, 360f);
            var spawnPosition = spawnRadius * new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad));
            var enemy = Instantiate(isRandom ? randomPrefab : prefab, spawnPosition, Quaternion.identity);
        }

        protected override void OnUpdate()
        {
            _timeSinceLastSpawn += Time.deltaTime;
            if (!(_timeSinceLastSpawn >= timeBetweenSpawns)) return;
            Spawn();
            _timeSinceLastSpawn = 0f;
        }
    }
}