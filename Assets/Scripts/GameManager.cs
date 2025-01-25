using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private float timeBetweenSpawns;
    private float _timeSinceLastSpawn = 0f;
    
    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= timeBetweenSpawns)
        {
            spawner.Spawn();
            _timeSinceLastSpawn = 0f;
        }
    }
}