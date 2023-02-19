using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVector = Vector3.up * _moveSpeed * Time.deltaTime;
        transform.Translate(moveVector, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(1);
        }
    }
}
