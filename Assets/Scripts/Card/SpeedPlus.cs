using Shooting;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create SpeedPlus", fileName = "SpeedPlus", order = 0)]
    public class SpeedPlus : CardEffect
    {
        [SerializeField] private BulletData bulletData;
        [SerializeField] private float amount = 2f;
        
        public override void Apply()
        {
            bulletData.IncreaseBulletSpeedBy(amount);
        }
    }
}