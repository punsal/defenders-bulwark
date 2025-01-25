using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = (Vector2.zero - (Vector2)transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}