using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Customize")]
    public float walkSpeed;
    public float jumpForce;

    // private vars
    Rigidbody2D rb;
    Vector2 moveVel;
    SpriteRenderer sr;
    AnimationHandler anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationHandler>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Walk(input);

        if (Input.GetButtonDown("Jump"))
        {
            // check if grounded
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
        }

        anim.SetHorizontalMovement(input.x, input.y, rb.velocity.y);

        if (input.x > 0)
        {
            int side = 1;
            anim.Flip(side);
        }
        if (input.x < 0)
        {
            int side = -1;
            anim.Flip(side);
        }
    }

    void Walk(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * walkSpeed, rb.velocity.y);
    }
}