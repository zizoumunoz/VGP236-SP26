using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _jumpSpeed = 30.0f;
    private Rigidbody2D _rigidBody = null;
    private float _desiredHorizontalMoveSpeed = 0;

    // player input hookups
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _jumpAction = null;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _jumpAction = _playerInput.Player.Jump;
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }

    void Update()
    {
        _desiredHorizontalMoveSpeed = _moveAction.ReadValue<Vector2>().x * _moveSpeed;
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _desiredHorizontalMoveSpeed;

    }
}
