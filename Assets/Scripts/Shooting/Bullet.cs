using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private float bulletLifeTime = 2f;
        private float _timer;
        private void Update()
        {
            Move();
            TryDispose();
        }

        private void Move()
        {
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        }

        private void TryDispose()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= bulletLifeTime)) return;
            Destroy(gameObject);
        }
    }
}