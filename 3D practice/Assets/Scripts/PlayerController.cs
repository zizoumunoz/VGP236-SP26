using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _turnSpeed = 1f;
    private Rigidbody _rigidBody = null;
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private Vector3 _moveVelocity = Vector3.zero;   // .zero in vectors gives you a vector of 0,0
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;

    }

    private void OnEnable()
    {
        _moveAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        _moveVelocity.x = moveInput.x * _speed;
        _moveVelocity.z = moveInput.y * _speed;
    }

    private void LateUpdate()
    {
        _moveVelocity.y = _rigidBody.linearVelocity.y;
        _rigidBody.linearVelocity = _moveVelocity;
    }
}
