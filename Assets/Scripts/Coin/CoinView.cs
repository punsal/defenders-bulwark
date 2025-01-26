using System.Collections.Generic;
using UnityEngine;

namespace Coin
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private CoinData coinData;
        [SerializeField] private List<GameObject> coinSlots;

        private void OnEnable()
        {
            coinData.CoinAmountChanged += ShowCoinAmount;
        }

        private void OnDisable()
        {
            coinData.CoinAmountChanged -= ShowCoinAmount;
        }

        private void Start()
        {
            ShowCoinAmount();
        }

        private void ShowCoinAmount()
        {
            var size = coinSlots.Count;
            for (var i = 0; i < size; i++)
            {
                var slot = coinSlots[i];
                slot.SetActive(i <= coinData.CoinAmount);
            }
        }
    }
}