using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
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
        if (other.attachedRigidbody.TryGetComponent(out Player player))
        {
            player.TakeDamage(-1);
            Destroy(gameObject);
        }
    }
}
