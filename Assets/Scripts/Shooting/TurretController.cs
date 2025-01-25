using Abstract;
using UnityEngine;

namespace Shooting
{
    public class TurretController : AGameBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;

        protected override void OnUpdate()
        {
            var rotDirection = Input.GetAxis(("Horizontal"));
        
            transform.Rotate(new Vector3(0f, 0f, -1f * rotDirection * rotationSpeed * Time.deltaTime));
        }
    }
}
