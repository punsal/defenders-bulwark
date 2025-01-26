using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    public class CardSlot : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private MonoBehaviour outline;
        
        private CardData _cardData;

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;
            image.sprite = _cardData.CardSprite;
        }

        public CardData GetCardData()
        {
            return _cardData;
        }

        public void Select()
        {
            outline.enabled = true;
        }

        public void Deselect()
        {
            outline.enabled = false;
        }
    }
}