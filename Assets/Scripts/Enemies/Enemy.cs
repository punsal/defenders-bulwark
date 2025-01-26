using Abstract;
using UnityEngine;

namespace Enemies
{
    public class Enemy : AGameBehaviour
    {
        [SerializeField] private GameObject deathEffect;

        private float _speed;

        public void Initialize(float speed)
        {
            _speed = speed;
        }

        private void Move()
        {
            var direction = (Vector2.zero - (Vector2)transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
        }

        public void Die()
        {
            Game.Events.OnDestroyed(this);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        protected override void OnUpdate()
        {
            Move();
        }
    }
}