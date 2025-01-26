using Abstract;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(menuName = "Create BulletData", fileName = "BulletData", order = 0)]
    public class BulletData : GameData
    {
        [SerializeField] private float bulletSpeed = 5f;
        public float BulletSpeed => bulletSpeed;
        public void Initialize(float speed)
        {
            if (IsInitialized) return;
            bulletSpeed = speed;
            Initialized();
        }

        public void IncreaseBulletSpeedBy(float value)
        {
            bulletSpeed += value;
        }
    }
}