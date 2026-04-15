using UnityEngine;

public class KillItemScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {


        // make sure it is the game object, otherwise its just the script
        Destroy(collision.gameObject);

    }
}
