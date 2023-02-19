using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private int _health;
    
    private void Update()
    {
        Turn();
        if (CheckFire()) Shoot();
    }

    private bool CheckFire()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private void Turn()
    {
        float turnAngle = 
            Input.GetAxis("Horizontal") * -_turnSpeed * Time.deltaTime;
        
        transform.Rotate(Vector3.forward, turnAngle);
    }

    private void Shoot()
    {
        Instantiate(
            _projectilePrefab,
            _shootPoint.position,
            _shootPoint.rotation
        );
    }

    public override void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("You Lose!");
            Time.timeScale = 0;
        }
    }
}
