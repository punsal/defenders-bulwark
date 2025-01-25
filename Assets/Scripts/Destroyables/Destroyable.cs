using UnityEngine;
using UnityEngine.Events;

namespace Destroyables
{
    public class Destroyable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onDestroyed;
        
        public void Destroy()
        {
            onDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}