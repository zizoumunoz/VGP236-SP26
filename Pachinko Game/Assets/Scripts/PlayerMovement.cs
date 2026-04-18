using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    private Vector2 velocity;

    [SerializeField] public int movementCooldown = 0;



    void Update()
    {
        float x = 0;
        if (movementCooldown > 0)
        {
            movementCooldown--;

        }

        if (Keyboard.current.aKey.isPressed && transform.position.x > -8 && movementCooldown == 0)
        {
            x = -1;
        }
        if (Keyboard.current.dKey.isPressed && transform.position.x < 8 && movementCooldown == 0)
        {
            x = 1;
        }

        velocity = new Vector2(x * movementSpeed, 0);
        transform.position += (Vector3)(velocity * Time.deltaTime); // REMEMBER TO USE DELTA TIME SO MOVEMENT ISNT FRAME TIED!!


    }
}
