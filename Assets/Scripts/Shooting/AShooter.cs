using Abstract;
using UnityEngine;

namespace Shooting
{
    public class AShooter : AGameBehaviour
    {
        public enum Type
        {
            Default,
            Shotgun,
            Raygun
        }
        [SerializeField] private Type type = Type.Default;
        [SerializeField] private ShooterData data;
        [SerializeField] private float initialFireRate = 2f;
        private float _fireTimer = 0f;
        
        public Type ShooterType => type;
        protected ShooterData Data => data;

        private void Start()
        {
            data.Initialize(initialFireRate);
        }

        protected virtual void Fire()
        {
            Instantiate(data.Prefab, transform.position, transform.rotation);
        }

        protected override void OnUpdate()
        {
            _fireTimer += Time.deltaTime;
            if (!(_fireTimer >= 1f / data.FireRate)) return;
            Fire();
            _fireTimer = 0f;
        }
    }
}