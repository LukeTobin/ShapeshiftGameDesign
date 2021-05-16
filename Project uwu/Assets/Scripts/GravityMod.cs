using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// graivty mode class for better jumping
public class GravityMod : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if our y velocity is less than 0, apply a fall multiplier
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // else, slowly drop the player
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
