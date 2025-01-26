using System;
using UnityEngine;

namespace Coin
{
    [CreateAssetMenu(menuName = "Create CoinData", fileName = "New CoinData", order = 0)]
    public class CoinData : ScriptableObject
    {
        [SerializeField] private int coinAmount;
        public int CoinAmount => coinAmount;
        public event Action CoinAmountChanged;

        public void Initialize(int amount)
        {
            coinAmount = amount;
        }
        
        public void AddCoin(int amount)
        {
            var newCoinAmount = coinAmount + amount;
            coinAmount = newCoinAmount > 10 ? 10 : newCoinAmount;
            CoinAmountChanged?.Invoke();
        }

        public void RemoveCoin(int amount)
        {
            var newAmount = coinAmount - amount;
            if (newAmount < 0)
            {
                throw new System.Exception("Cannot remove more coins than " + coinAmount);
            }
            coinAmount = newAmount;
            CoinAmountChanged?.Invoke();
        }
    }
}