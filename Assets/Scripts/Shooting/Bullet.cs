using System;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletData bulletData;
        [SerializeField] private float speed;
        [SerializeField] private float bulletLifeTime = 2f;
        private float _timer;

        private void Start()
        {
            bulletData.Initialize(speed);
        }

        private void Update()
        {
            Move();
            TryDispose();
        }

        private void Move()
        {
            transform.Translate(Vector3.right * (bulletData.BulletSpeed * Time.deltaTime));
        }

        private void TryDispose()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= bulletLifeTime)) return;
            Destroy(gameObject);
        }
    }
}