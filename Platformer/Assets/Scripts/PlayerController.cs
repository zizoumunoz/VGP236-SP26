using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // animating stuff
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundCheck _groundCheck; // for the ground check script
    [SerializeField] private SpriteRenderer _spriteRenderer;


    // because its a platformer, not vertical movement, just jump movement
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpSpeed;
    private Rigidbody2D _rigidBody = null;
    private float _targetMoveSpeed = 0;

    // player input hookups
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _jumpAction = null;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();   // get rigid body attached to this script's object
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _jumpAction = _playerInput.Player.Jump;

        // when jumpAction is performed, call the OnJump() function. .performed is an event
        _jumpAction.performed += OnJump;
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
        _targetMoveSpeed = _moveAction.ReadValue<Vector2>().x * _movementSpeed;
        // set the animators speed param so blend trees can use it
        _animator.SetFloat("Speed", Mathf.Abs(_targetMoveSpeed));
        _animator.SetFloat("SpeedY", _rigidBody.linearVelocityY);
        _animator.SetBool("Grounded", _groundCheck.IsGrounded);
        if (_targetMoveSpeed > 0.1f)
        {
            _spriteRenderer.flipX = false; // don't flip whatever sprite is playing when the speed is going right
        }
        else if (_targetMoveSpeed < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }

        Debug.Log("Target Move Speed: "+_targetMoveSpeed);

    }

    // Like Update() but not frame based, for physics
    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _targetMoveSpeed;
    }

    void OnJump(InputAction.CallbackContext context)
    {
        _rigidBody.linearVelocityY = _jumpSpeed;
    }

}
