using System.Collections.Generic;
using System.Linq;
using Coin;
using UnityEngine;

namespace Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private CardSlot prefab;
        [SerializeField] private List<CardData> cards = new List<CardData>();
        
        [SerializeField] private CoinData coin;

        private CardData _selectedCard;
        
        private void OnEnable()
        {
            Game.Machine.OnStateChangeEvent += OnStateChangeEvent;
            Game.Events.CardSelected += OnCardSelected;
            Game.Events.AppleCardEffect += OnApplyCardEffect;
        }

        private void OnDisable()
        {
            Game.Machine.OnStateChangeEvent -= OnStateChangeEvent;
            Game.Events.CardSelected -= OnCardSelected;
            Game.Events.AppleCardEffect -= OnApplyCardEffect;
        }

        private void OnStateChangeEvent(Game.Machine.State state)
        {
            if (state == Game.Machine.State.Card)
            {
                var size = cards.Count;
                if (size < 3)
                {
                    foreach (var card in cards)
                    {
                        var slot = Instantiate(prefab, transform);
                        slot.Initialize(card);
                    }
                }
                else
                {
                    var temp = new List<CardData>(cards);
                    for (var i = 0; i < 3; i++)
                    {
                        var random = Random.Range(0, temp.Count);
                        var selection = temp[random];
                        temp.RemoveAt(random);
                        
                        var slot = Instantiate(prefab, transform);
                        slot.Initialize(selection);
                        slot.Deselect();
                    }
                }
            }
            else
            {
                var children = GetComponentsInChildren<CardSlot>().ToList();
                while (children.Count > 0)
                {
                    var child = children[0];
                    children.Remove(child);
                    Destroy(child.gameObject);
                }
            }
        }

        private void OnCardSelected(int cardIndex)
        {
            var children = GetComponentsInChildren<CardSlot>().ToList();
            foreach (var child in children)
            {
                child.Deselect();
            }

            var cardSlot = transform.GetChild(cardIndex).GetComponent<CardSlot>();
            cardSlot.Select();
            _selectedCard = cardSlot.GetCardData();
        }

        private void OnApplyCardEffect()
        {
            if (_selectedCard == null)
            {
                return;
            }

            if (_selectedCard.Cost > coin.CoinAmount)
            {
                return;
            }
            
            coin.RemoveCoin(_selectedCard.Cost);
            _selectedCard?.CardEffect.Apply();
        }
    }
}