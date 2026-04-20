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
    [SerializeField] private int _xMax = -8;
    [SerializeField] private int _xMin = 8;

    [SerializeField] private int _yMax = 5;
    [SerializeField] private int _yMin = 2;



    void Update()
    {
        float x = 0;
        float y = 0;
        if (movementCooldown > 0)
        {
            movementCooldown--;

        }

        if (Keyboard.current.aKey.isPressed && transform.position.x > _xMax && movementCooldown == 0)
        {
            x = -1;
        }
        if (Keyboard.current.dKey.isPressed && transform.position.x < _xMin && movementCooldown == 0)
        {
            x = 1;
        }

        // up down movement
        if (Keyboard.current.wKey.isPressed && transform.position.y < _yMax && movementCooldown == 0)
        {
            y = 1;
        }
        if (Keyboard.current.sKey.isPressed && transform.position.y > _yMin && movementCooldown == 0)
        {
            y = -1;
        }

        velocity = new Vector2(x * movementSpeed, y * movementSpeed);
        transform.position += (Vector3)(velocity * Time.deltaTime); // REMEMBER TO USE DELTA TIME SO MOVEMENT ISNT FRAME TIED!!


    }
}
