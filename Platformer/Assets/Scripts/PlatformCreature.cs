using UnityEngine;

public class PlatformCreature : MonoBehaviour
{
    [SerializeField] public float _speed = 3f;
    private Vector2 _direction = Vector2.zero;

    // make player stick so they don't slide off
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // collision.collider means the incoming collider, in this case the player
            // Player is parented so it moves along with the platform
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }


    void Update()
    {
        transform.position += (Vector3)(_direction * _speed * Time.deltaTime);
    }

    // methods for SendMessage()

    public void Up()
    {
        _direction = Vector2.up;
    }
    public void Down()
    {
        _direction = Vector2.down;
    }
    public void Left()
    {
        _direction = Vector2.left;
    }
    public void Right()
    {
        _direction = Vector2.right;
    }

    public void Deactivate()
    {
        _direction = Vector2.zero;
    }

}
