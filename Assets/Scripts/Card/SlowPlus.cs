using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create SlowPlus", fileName = "New SlowPlus", order = 0)]
    public class SlowPlus : CardEffect
    {
        [SerializeField] private float amount = 0.1f;
        [SerializeField] private List<EnemyData> enemyData;
        
        public override void Apply()
        {
            foreach (var data in enemyData)
            {
                data.DecreaseMovementSpeed(amount);
            }    
        }
    }
}