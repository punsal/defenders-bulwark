using UnityEngine;
using UnityEngine.Events;

namespace Destroyables
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private UnityEvent onDestroy;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.attachedRigidbody.TryGetComponent<Destroyable>(out var result)) return;
            Destroy(result);
            onDestroy?.Invoke();
        }

        protected virtual void Destroy(Destroyable destroyable)
        {
            destroyable.Destroy();
        }
    }
}