using Abstract;
using UnityEngine;

namespace Shooting
{
    [CreateAssetMenu(menuName = "Create ShooterData", fileName = "ShooterData", order = 0)]
    public class ShooterData : GameData
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private float fireRate = 2f;
        
        public Bullet Prefab => prefab;
        public float FireRate => fireRate;

        public void Initialize(float rate)
        {
            fireRate = rate;
        }

        public void IncreaseFireRate(float value)
        {
            fireRate *= 1f + value;
        }
    }
}