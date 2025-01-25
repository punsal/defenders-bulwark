using Abstract;
using UnityEngine;

namespace Shooting
{
    public class Shooter : AGameBehaviour
    {
        [SerializeField] private Bullet prefab;
        [SerializeField] private float fireRate = 2f;

        private float _fireTimer = 0f;

        private void Fire()
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }

        protected override void OnUpdate()
        {
            _fireTimer += Time.deltaTime;
            if (!(_fireTimer >= 1f / fireRate)) return;
            Fire();
            _fireTimer = 0f;
        }
    }
}