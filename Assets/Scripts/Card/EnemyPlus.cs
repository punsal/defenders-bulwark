using Coin;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create EnemyPlus", fileName = "New EnemyPlus", order = 0)]
    public class EnemyPlus : CardEffect
    {
        [SerializeField] private CoinData coinData;
        [SerializeField] private float amount = 0.1f;
        
        public override void Apply()
        {
            coinData.IncreasePercentage(amount);
        }
    }
}