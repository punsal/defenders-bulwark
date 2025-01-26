using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Create EnemySpawnData", fileName = "New EnemySpawnData", order = 0)]
    public class EnemySpawnData : ScriptableObject
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private float timeBetweenSpawns;
        [SerializeField] private int amount;
        
        private int _currentAmount;
        
        public float Timer { get; private set; }

        public void AddTime(float time) => Timer += time;
        public void ResetTimer() => Timer = 0f;
        
        public float TimeBetweenSpawns => timeBetweenSpawns;

        public void Initialize()
        {
            _currentAmount = amount;
        }
        
        public EnemyData EnemyData => enemyData;
        public int Amount => _currentAmount < 0 ? 0 : _currentAmount;

        public void EnemySpawned()
        {
            _currentAmount--;
        }
    }
}