using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GroundCheck _groundCheck = null;
    [SerializeField] private float _moveSpeed = 8.0f;
    [SerializeField] private float _jumpSpeed = 5.0f;
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
        _jumpAction.performed += OnJump; // when jump action, it will call the function we made called OnJump
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

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_groundCheck.IsGrounded && _rigidBody.linearVelocityY < 0.1f)
        {
            _rigidBody.linearVelocityY = _jumpSpeed;

        }
    }
}
