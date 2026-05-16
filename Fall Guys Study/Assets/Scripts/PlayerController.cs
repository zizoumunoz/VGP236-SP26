using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    // groundcheck without making a child object
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.2f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 2f;



    [SerializeField]private bool _isGrounded;

    private Rigidbody _rigidBody;
    private Animator _animator;
    private Vector2 _moveInput;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        Vector3 move = new Vector3(_moveInput.x, 0f, _moveInput.y);

        Vector3 targetVelocity = move * _moveSpeed;
        targetVelocity.y = _rigidBody.linearVelocity.y;

        _rigidBody.linearVelocity = targetVelocity;

        Vector3 lookDirection = move;
        if (lookDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            _rigidBody.MoveRotation(targetRotation);
        }

        _animator.SetFloat("Speed", move.magnitude);
    }

    public void OnJump()
    {
        if (_isGrounded)
        {
            Vector3 vel = _rigidBody.linearVelocity;
            vel.y = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
            _rigidBody.linearVelocity = vel;
        }
    }

}
