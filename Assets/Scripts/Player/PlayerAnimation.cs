using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    private SpriteRenderer playerSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movement.moveDirection.x != 0 || movement.moveDirection.y != 0) {
            if (Mathf.Abs(movement.moveDirection.x) > Mathf.Abs(movement.moveDirection.y)) {
                animator.SetBool("MoveLeftRight", true);
                animator.SetBool("MoveUp", false);
                animator.SetBool("MoveDown", false);
                SetSpriteDirection();
            } else {
                animator.SetBool("MoveLeftRight", false);
                animator.SetBool(movement.moveDirection.y > 0 ? "MoveUp" : "MoveDown", true);
            }
        }
        else {
            animator.SetBool("MoveLeftRight", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveDown", false);
        }
    }

    void SetSpriteDirection()
    {
        playerSprite.flipX = movement.moveDirection.x > 0;
    }
}
