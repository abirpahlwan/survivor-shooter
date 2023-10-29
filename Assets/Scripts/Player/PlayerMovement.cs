using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Data")]
    public CharacterScriptableObject playerData;
    
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public Vector2 lastMoveDirection;
    [HideInInspector] public float lastMoveX;
    [HideInInspector] public float lastMoveY;
    
    private Rigidbody2D rb;
    
    /*public enum Direction
    {
        Right = 0,
        UpRight = 1,
        Up = 2,
        UpLeft = 3,
        Left = 4,
        DownLeft = 5,
        Down = 6,
        DownRight = 7
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMoveDirection = new Vector2(1, 0);
    }

    void Update()
    {
        HandleInput();
        // HandleDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * playerData.MoveSpeed, moveDirection.y * playerData.MoveSpeed);
    }

    void HandleInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x != 0)
        {
            lastMoveX = moveDirection.x;
            lastMoveDirection = new Vector2(lastMoveX, 0);
        }
        
        if (moveDirection.y != 0)
        {
            lastMoveY = moveDirection.y;
            lastMoveDirection = new Vector2(0, lastMoveY);
        }

        if (moveDirection.x != 0 && moveDirection.y != 0)
        {
            lastMoveDirection = new Vector2(lastMoveX, lastMoveY);
        }
    }

    /*void HandleDirection()
    {
        // 0 degrees is to the right, and the angle increases counter-clockwise
        float angleDegrees = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        
        // Normalize the angle to be between 0 and 360
        if (angleDegrees < 0) {
            angleDegrees += 360;
        }

        // Determine the direction based on angle
        currentDirection = (int) angleDegrees / 45;
    }*/
}
