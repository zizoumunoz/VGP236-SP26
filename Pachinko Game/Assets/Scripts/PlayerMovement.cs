using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed = 5f;
    public Vector2 velocity;

    void Update()
    {
        float x = 0;

        if (Keyboard.current.aKey.isPressed && transform.position.x > -8)
        {
            x = -1;
        }
        if (Keyboard.current.dKey.isPressed && transform.position.x < 8)
        {
            x = 1;
        }

        velocity = new Vector2(x * movementSpeed, 0);
        transform.position += (Vector3)(velocity * Time.deltaTime); // REMEMBER TO USE DELTA TIME SO MOVEMENT ISNT FRAME TIED!!


    }
}
