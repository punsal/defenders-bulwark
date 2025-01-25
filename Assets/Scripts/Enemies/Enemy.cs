using Abstract;
using UnityEngine;

namespace Enemies
{
    public class Enemy : AGameBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private GameObject deathEffect;

        private void Move()
        {
            var direction = (Vector2.zero - (Vector2)transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }

        public void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        protected override void OnUpdate()
        {
            Move();
        }
    }
}