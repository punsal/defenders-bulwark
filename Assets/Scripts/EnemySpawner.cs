using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy prefab;
    [SerializeField] private float spawnRadius = 10f;
    
    public void Spawn() 
    { 
        var angle = Random.Range(0f, 360f);
        var spawnPosition = spawnRadius * new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad));
        Instantiate(prefab, spawnPosition, Quaternion.LookRotation(Vector3.zero));
    }
}