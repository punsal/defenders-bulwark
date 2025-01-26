using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create BubblePlus", fileName = "New BubblePlus", order = 0)]
    public class BubblePlus : CardEffect
    {
        public override void Apply()
        {
            Game.Events.OnAddBubble();
        }
    }
}