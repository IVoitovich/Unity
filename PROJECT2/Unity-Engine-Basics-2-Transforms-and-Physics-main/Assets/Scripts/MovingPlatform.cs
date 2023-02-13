using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 _firstPosition;
    [SerializeField] private Vector3 _secondPosition;
    [SerializeField] private float _speed;

    private bool _isMovingForward = true;
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        _rigidbody.position = _firstPosition;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 way;
        if (_isMovingForward)
            way = _secondPosition - _rigidbody.position;
        else
            way = _firstPosition - _rigidbody.position;
        
        Vector3 direction = way.normalized;
        Vector3 moveVector = direction * _speed * Time.deltaTime;
        
        // Do not move further than need
        if (moveVector.magnitude >= way.magnitude)
        {
            moveVector = way;
            _isMovingForward = !_isMovingForward;
        }
        
        _rigidbody.position += moveVector;
    }
}
