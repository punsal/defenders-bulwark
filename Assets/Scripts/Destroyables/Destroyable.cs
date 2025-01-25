using UnityEngine;

namespace Destroyables
{
    public class Destroyable : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}