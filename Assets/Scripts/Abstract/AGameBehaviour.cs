using UnityEngine;

namespace Abstract
{
    public abstract class AGameBehaviour : MonoBehaviour
    {
        private void OnEnable()
        {
            Game.AddUpdate(OnUpdate);
        }

        private void OnDisable()
        {
            Game.RemoveUpdate(OnUpdate);
        }
        
        protected abstract void OnUpdate();
    }
}