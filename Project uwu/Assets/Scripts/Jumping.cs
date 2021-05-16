using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rb;

    void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if the player is grounded and in their normal state, apply a simple jump
        if (Input.GetButtonDown("Jump") && player.isGrounded && player.isNormal)
        {
            rb.velocity = Vector2.up * player.jumpForce;
        }
    }

}
