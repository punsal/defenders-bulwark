using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create CardData", fileName = "New CardData", order = 0)]
    public class CardData : ScriptableObject
    {
        [SerializeField] private Sprite cardSprite;
        [SerializeField] private CardEffect cardEffect;
        [SerializeField] private int cost;
        
        public Sprite CardSprite => cardSprite;
        public CardEffect CardEffect => cardEffect;
        public int Cost => cost;
    }
}