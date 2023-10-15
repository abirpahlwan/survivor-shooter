using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float moveSpeed;
    
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    
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
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed );
    }

    void HandleInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x != 0)
        {
            lastHorizontalVector = moveDirection.x;
        }
        
        if (moveDirection.y != 0)
        {
            lastVerticalVector = moveDirection.y;
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
