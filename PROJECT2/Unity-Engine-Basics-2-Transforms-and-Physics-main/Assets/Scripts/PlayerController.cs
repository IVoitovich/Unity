using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force = 400;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _playerRadius = 1;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private const float EPSILON = 0.001f;
    public GameObject currentHitObject;

    private float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        CheckGround();
        Jump();
        Destroy();
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetButton("Jump"))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime);
            _isGrounded = false;
        }
    }

    private void CheckGround()
    {
        RaycastHit hit;
        _isGrounded = Physics.SphereCast(transform.position, 1, Vector3.forward, out hit, 10);
    }

    private void Move()
    {
        _rigidbody.AddForce(
            Vector3.forward * Input.GetAxis("Vertical") * _force * Time.deltaTime);
        
        _rigidbody.AddForce(
            Vector3.right * Input.GetAxis("Horizontal") * _force * Time.deltaTime);
    }
    private void Destroy()
    {
        if(_rigidbody.position.y<-10f){
            Destroy(_rigidbody);
            SceneManager.LoadScene(0);
        }
    }
}
