using Shooting;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "Create AddRaygun", fileName = "AddRaygun", order = 0)]
    public class AddRaygun : CardEffect
    {
        public override void Apply()
        {
            Game.Events.OnAddShooter(AShooter.Type.Raygun);
        }
    }
}