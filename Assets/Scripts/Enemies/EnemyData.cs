using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Create EnemyData", fileName = "New EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private Enemy prefab;
        [SerializeField] private float movementSpeed;
        
        public Enemy Prefab => prefab;
        public float MovementSpeed => movementSpeed;
    }
}