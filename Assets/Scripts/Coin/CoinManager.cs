using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Coin
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private CoinData coinData;
        [SerializeField] private GameObject coinPrefab;
        [SerializeField, Range(0f, 1f)] private float percentage;
        
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
            coinData.Initialize(0);
        }

        private void OnDestroyed(Enemy enemy)
        {
            var rng = Random.Range(0f, 1f);
            if (!(rng <= percentage))
            {
                return;
            }
            
            Instantiate(coinPrefab, enemy.transform.position, Quaternion.identity);
            coinData.AddCoin(1);
        }
    }
}
