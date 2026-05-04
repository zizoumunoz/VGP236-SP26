using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private enum PlayerType { Player1, Player2 }
    [SerializeField] private PlayerType playerType;


    // animating stuff
    [SerializeField] private Animator _animator;
    [SerializeField] private GroundCheck _groundCheck; // for the ground check script
    [SerializeField] private SpriteRenderer _spriteRenderer;


    // because its a platformer, not vertical movement, just jump movement
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpSpeed;
    private Rigidbody2D _rigidBody = null;
    private float _targetMoveSpeed = 0;

    [SerializeField] float _coyoteTime = 0.1f;
    private float _coyoteCounter = 0;



    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();   // get rigid body attached to this script's object

    }



    void Update()
    {
        _targetMoveSpeed = GetHorizontalInput() * _movementSpeed;
        // set the animators speed param so blend trees can use it
        _animator.SetFloat("Speed", Mathf.Abs(_targetMoveSpeed));
        _animator.SetFloat("SpeedY", _rigidBody.linearVelocityY);
        _animator.SetBool("Grounded", _groundCheck.IsGrounded);

        // coyote time logic
        if (_groundCheck.IsGrounded)
        {
            _coyoteCounter = _coyoteTime;
        }
        else
        {
            _coyoteCounter -= Time.deltaTime;
        }

        if (_targetMoveSpeed > 0.1f)
        {
            _spriteRenderer.flipX = false; // don't flip whatever sprite is playing when the speed is going right
        }
        else if (_targetMoveSpeed < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }

        if (GetJumpPressed() && _coyoteCounter > 0f)
        {
            _rigidBody.linearVelocityY = _jumpSpeed;
            _coyoteCounter = 0f;
        }
    }

    // Like Update() but not frame based, for physics
    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _targetMoveSpeed;
    }

    private float GetHorizontalInput()
    {
        if (playerType == PlayerType.Player1)
        {
            // WASD
            float x = 0f;
            if (Input.GetKey(KeyCode.D)) x += 1f;
            if (Input.GetKey(KeyCode.A)) x -= 1f;
            return x;
        }
        else
        {
            // Arrow keys
            float x = 0f;
            if (Input.GetKey(KeyCode.RightArrow)) x += 1f;
            if (Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
            return x;
        }
    }

    private bool GetJumpPressed()
    {
        if (playerType == PlayerType.Player1)
            return Input.GetKeyDown(KeyCode.W); // or Space if you prefer

        return Input.GetKeyDown(KeyCode.UpArrow); // or RightControl
    }




}
