using Abstract;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : AGameBehaviour
    {
        [SerializeField] private Enemy prefab;
        [SerializeField] private float spawnRadius = 10f;
    
        [SerializeField] private float timeBetweenSpawns;
        private float _timeSinceLastSpawn = 0f;

        private void Spawn() 
        { 
            var angle = Random.Range(0f, 360f);
            var spawnPosition = spawnRadius * new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad),
                Mathf.Sin(angle * Mathf.Deg2Rad));
            var enemy = Instantiate(prefab, spawnPosition, Quaternion.identity);
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