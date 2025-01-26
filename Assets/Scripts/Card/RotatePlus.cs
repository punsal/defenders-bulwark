using Shooting;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create RotatePlus", fileName = "New RotatePlus", order = 0)]
    public class RotatePlus : CardEffect
    {
        [SerializeField] private RotateSpeed data;
        [SerializeField] private float amount;
        
        public override void Apply()
        {
            data.IncreaseRotationSpeed(amount);    
        }
    }
}