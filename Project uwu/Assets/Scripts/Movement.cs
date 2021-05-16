using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 playerInput;
    float dir;
    float dirV;

    Rigidbody2D rb;
    PlayerController player;
    BoxCollider2D coll;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Normal Movement
        if (player.isNormal)
        {
            // normal input movement system
            dir = Input.GetAxisRaw("Horizontal");
            player.currentSpeed = dir * player.moveSpeed;
            rb.velocity = new Vector2(player.currentSpeed, rb.velocity.y);
        }

        // Fly Movement
        if (player.isFly && !player.isNormal && !player.isSnake)
        {
            // gravity no longer affects the player and they can move in multiple directions
            dir = Input.GetAxisRaw("Horizontal");
            dirV = Input.GetAxisRaw("Vertical");
            player.currentSpeed = dir * player.FlySpeed;
            rb.velocity = new Vector2(player.currentSpeed, dirV * player.FlySpeed);
        }

        // Snake Movement
        if (player.isSnake && !player.isNormal && !player.isFly)
        {   
            // if the player is touch a wall, they can move directly up it
            if (player.isTouchingLeft || player.isTouchingRight){

                dir = Input.GetAxisRaw("Horizontal");
                dirV = Input.GetAxisRaw("Vertical");

                // if the player is going up a wall, remove gravity
                if(dir < .1f || dir > -.1f)
                {
                    rb.gravityScale = 0;
                    player.currentSpeed = dirV * player.SnakeSpeed;
                    rb.velocity = new Vector2(rb.velocity.x, player.currentSpeed);
                }
                else
                {
                    rb.gravityScale = 3;
                    player.currentSpeed = dir * player.SnakeSpeed;
                    rb.velocity = new Vector2(player.currentSpeed, rb.velocity.y);
                }
            }
            else
            {
                // otherwise return to normal movement
                rb.gravityScale = 3;
                
                dir = Input.GetAxisRaw("Horizontal");
                player.currentSpeed = dir * player.SnakeSpeed;
                rb.velocity = new Vector2(player.currentSpeed, rb.velocity.y);
            }
        }

        if (rb.gravityScale != 3)
        {
            if (!player.isTouchingLeft || !player.isTouchingRight)
            {
                rb.gravityScale = 3;
            }
        }

        if (player.flipSide == false && dir > 0)
        {
            // flip
        }
        else if(player.flipSide == true && dir < 0)
        {
            // flip
        }
    }
}
