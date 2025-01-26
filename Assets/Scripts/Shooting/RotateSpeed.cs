using Abstract;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(menuName = "Create RotateSpeed", fileName = "New RotateSpeed", order = 0)]
    public class RotateSpeed : GameData
    {
        [SerializeField] private float rotationSpeed = 100f;
        public float RotationSpeed => rotationSpeed;

        public void Initialize(float speed)
        {
            rotationSpeed = speed;
        }
        
        public void IncreaseRotationSpeed(float amount)
        {
            rotationSpeed += amount;
        }
    }
}