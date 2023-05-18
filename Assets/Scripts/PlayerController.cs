using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    new Rigidbody2D rigidbody2D;
    [HideInInspector]
    public Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }

    void Move()
    {
        rigidbody2D.velocity = movementDirection * moveSpeed;
    }
}
