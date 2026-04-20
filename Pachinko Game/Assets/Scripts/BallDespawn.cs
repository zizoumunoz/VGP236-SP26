using UnityEngine;

public class BallDespawn : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            Destroy(gameObject);

        }
    }
}
