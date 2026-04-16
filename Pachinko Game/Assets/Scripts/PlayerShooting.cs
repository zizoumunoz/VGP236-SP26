using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject ballPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
