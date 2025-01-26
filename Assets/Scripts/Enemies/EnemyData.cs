using Abstract;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Create EnemyData", fileName = "New EnemyData", order = 0)]
    public class EnemyData : GameData
    {
        [SerializeField] private Enemy prefab;
        [SerializeField] private float movementSpeed;
        
        public Enemy Prefab => prefab;
        public float MovementSpeed => movementSpeed;

        public void Initialize(float speed)
        {
            if (IsInitialized)
            {
                return;
            }
            
            movementSpeed = speed;
            Initialized();
        }
        
        public void DecreaseMovementSpeed(float amount)
        {
            movementSpeed *= 1f - amount;
        }
    }
}