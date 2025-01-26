using UnityEngine;

namespace Abstract
{
    public abstract class GameData : ScriptableObject
    {
        private bool _isInitialized;
        protected bool IsInitialized => _isInitialized;

        protected void Initialized()
        {
            _isInitialized = true;
        }
        
        public void RevertChanges()
        {
            _isInitialized = false;
        }
    }
}