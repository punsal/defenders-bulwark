using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Coin
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private CoinData coinData;
        [SerializeField] private GameObject coinPrefab;
        
        private void OnEnable()
        {
            Game.Events.Destroyed += OnDestroyed;
        }

        private void OnDisable()
        {
            Game.Events.Destroyed -= OnDestroyed;
        }

        private void Start()
        {
            coinData.Initialize(0, 0.2f);
        }

        private void OnDestroyed(Enemy enemy)
        {
            var rng = Random.Range(0f, 1f);
            if (!(rng <= coinData.Percentage))
            {
                return;
            }
            
            Instantiate(coinPrefab, enemy.transform.position, Quaternion.identity);
            coinData.AddCoin(1);
        }
    }
}
