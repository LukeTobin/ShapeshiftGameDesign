using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{

    Animator anim;
    SpriteRenderer sr;
    PlayerController player;
    Collision col;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collision>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isGrounded", col.onGround);
    }

    public void SetHorizontalMovement(float x, float y, float yVel)
    {
        anim.SetFloat("Walking", Mathf.Abs(x));
        anim.SetFloat("Jumping", Mathf.Abs(y));
    }

    public void Flip(int side)
    {
        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
