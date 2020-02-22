using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Customize")]
    public float fall;
    public float minJump;

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    MovementController mc;
    Collision col;
    Jumping jump;
    Rigidbody2D rb;
    AnimationHandler anim;


    private void Start()
    {
        mc = GetComponent<MovementController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<AnimationHandler>();
    }
}
