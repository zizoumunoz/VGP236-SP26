using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _shoulderTransform = null;
    [SerializeField] private GroundCheck _groundCheck = null;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _turnSpeed = 1f;
    [SerializeField] private float _jumpSpeed = 10.0f;
    [SerializeField] private bool _invertY = false;
    [SerializeField] private float _maxPitchAngle = 70f;
    [SerializeField] private float _minPitchAngle = -70f;


    private Rigidbody _rigidBody = null;
    private PlayerInput _playerInput = null;
    private InputAction _moveAction = null;
    private InputAction _jumpAction = null;
    private InputAction _lookAction = null;
    private Vector3 _moveVelocity = Vector3.zero;   // .zero in vectors gives you a vector of 0,0
    private Vector3 _moveRotation = Vector3.zero;

    private float _pitchRotation = 0.0f;
    private int _initalFrameSkip = 2;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _playerInput = new PlayerInput();
        _moveAction = _playerInput.Player.Move;
        _jumpAction = _playerInput.Player.Jump;
        _jumpAction.performed += OnJump;
        _lookAction = _playerInput.Player.Look;

        // hide cursor /lock to screen, (press escto show cursor again to pause/quit)

        Cursor.lockState = CursorLockMode.Locked;

    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _lookAction.Enable();
        _jumpAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _jumpAction.Disable();
    }



    // Update is called once per frame
    void Update()
    {
        if (_initalFrameSkip > 0)
        {
            --_initalFrameSkip;
            return;
        }
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector2 lookInput = _lookAction.ReadValue<Vector2>();
        
        // wasd move control, move facing camera, strafe
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0.0f; // sometimes tilting can mess up your y axis, so you wanna fix it to zero
        right.y = 0.0f;
        _moveVelocity = ((forward * moveInput.y) + (right * moveInput.x)) * _speed;



        _moveRotation.y = lookInput.x * _turnSpeed;

        if (_invertY)
        {
            lookInput.y *= -1.0f;
        }
        _pitchRotation = Mathf.Clamp(_pitchRotation + lookInput.y, _minPitchAngle, _maxPitchAngle);
    }

    private void FixedUpdate()
    {
        _moveVelocity.y = _rigidBody.linearVelocity.y;
        _rigidBody.linearVelocity = _moveVelocity;
        _rigidBody.angularVelocity = _moveRotation;
        _shoulderTransform.localRotation = Quaternion.Euler(_pitchRotation, 0.0f, 0.0f);
    }

    private void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (_rigidBody.linearVelocity.y < 0.1f && _groundCheck.IsGrounded)
        {
            Vector3 jumpVelocity = _rigidBody.linearVelocity;
            jumpVelocity.y = _jumpSpeed;
            _rigidBody.linearVelocity = jumpVelocity;
        }
    }
}
