using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    PlayerController playerController;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("MovingUp", false);
        animator.SetBool("MovingDown", false);

        if (!playerController.movementDirection.Equals(Vector2.zero))
        {
            animator.SetBool("Moving", true);
            UpdateSpriteDirection();
        } 
        
        if (playerController.movementDirection.Equals(Vector2.up))
        {
            animator.SetBool("MovingUp", true);
        } else if (playerController.movementDirection.Equals(Vector2.down))
        {
            animator.SetBool("MovingDown", true);
        }
    }

    void UpdateSpriteDirection()
    {
        if (playerController.movementDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        }
    }
}
