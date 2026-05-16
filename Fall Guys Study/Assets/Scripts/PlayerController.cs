using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidBody;
    private Vector2 _moveInput;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
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
    }

}
