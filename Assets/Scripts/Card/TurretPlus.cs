using Shooting;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create TurretPlus", fileName = "TurretPlus", order = 0)]
    public class TurretPlus : CardEffect
    {
        [SerializeField] private ShooterData shooterData;
        [SerializeField] private float amount = 0.2f;
        
        public override void Apply()
        {
            shooterData.IncreaseFireRate(amount);    
        }
    }
}