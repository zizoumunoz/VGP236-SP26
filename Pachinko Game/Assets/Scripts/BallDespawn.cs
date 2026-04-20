using UnityEngine;

public class BallDespawn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Destroy(gameObject);

        }
    }
}
