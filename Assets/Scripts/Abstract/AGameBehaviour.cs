using UnityEngine;

namespace Abstract
{
    public abstract class AGameBehaviour : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            Game.AddUpdate(OnUpdate);
        }

        protected virtual void OnDisable()
        {
            Game.RemoveUpdate(OnUpdate);
        }
        
        protected abstract void OnUpdate();
    }
}