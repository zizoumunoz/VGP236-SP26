using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject ballPrefab;
    private PlayerMovementScript playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            playerMovement.movementCooldown = 30;
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
