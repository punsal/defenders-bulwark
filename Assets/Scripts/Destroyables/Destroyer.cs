using UnityEngine;

namespace Destroyables
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody.TryGetComponent<Destroyable>(out var result))
            {
                Destroy(result);
            }
        }

        protected virtual void Destroy(Destroyable destroyable)
        {
            destroyable.Destroy();
        }
    }
}