using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D playerRigidbody;

    [HideInInspector]
    public Vector2 movementDirection;
    [HideInInspector]
    public Vector2 weaponMovementDirection;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        weaponMovementDirection = new Vector2(1, 0);
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(moveX, moveY).normalized;

        if (!movementDirection.Equals(Vector2.zero))
        {
            weaponMovementDirection = movementDirection;
        }
    }

    void Move()
    {
        playerRigidbody.velocity = movementDirection * moveSpeed;
    }
}
