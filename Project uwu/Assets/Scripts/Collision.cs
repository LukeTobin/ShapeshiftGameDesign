using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        // Update Fix bools
        player.isGrounded = Physics2D.OverlapCircle(player.groundCheck.position, player.checkRadius, player.whatIsGround);
        player.isTouchingLeft = Physics2D.OverlapCircle(player.wallCheckLeft.position, player.checkRadius, player.whatIsGround);
        player.isTouchingRight = Physics2D.OverlapCircle(player.wallCheckRight.position, player.checkRadius, player.whatIsGround);
    }
}
