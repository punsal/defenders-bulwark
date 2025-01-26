using UnityEngine;

namespace Card
{
    public abstract class CardEffect : ScriptableObject
    {
        public abstract void Apply();
    }
}