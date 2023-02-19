using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Entity
{    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Enemy _enemy;
  
    public GameObject item;
    public float prob=25;
    float rnd;

     

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
            player.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    public override void TakeDamage(int damage)
    { 
        rnd=Random.Range(0, 100);
        if(rnd<=prob){
         Destroy(gameObject);
         GameObject Drop=Instantiate(item, transform.position, transform.rotation);
         }else{
       Destroy(gameObject);           
        }
    }
}
