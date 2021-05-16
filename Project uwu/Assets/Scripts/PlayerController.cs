using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed; // speed of a player
    public float currentSpeed;
    [Space]

    public float jumpForce; // how high the player jumps
    public float fallMultiplier; // how fast the player falls
    public float lowJumpMultiplier; // how much the player jumps if a light input is used
    [Space]
    public bool flipSide = true; // should the player flip sprite
    [Space]

    [Header("Collision")]
    // collision checking bools
    public Transform groundCheck;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public bool isTouchingLeft;
    public bool isTouchingRight;
    [Space]

    [Header("Shapeshifting")]
    // states, should have been done in enums
    public bool isNormal = true;
    public bool isFly;
    public bool isSnake;
    [Space]

    // previous states
    public bool wasFly;
    public bool wasSnake;
    [Space]

    // speed of each state
    public float FlySpeed;
    public float FlyJump;
    public float SnakeSpeed;
    [Space]

    // sprite for each state
    public Sprite normal;
    public Sprite fly;
    public Sprite snake;
    [Space]

    // cooldown to swap between states
    public float CooldownTime;

    SpriteRenderer sr;
    GameController gc;
    Animator animator;

    float snakeCD;
    float flyCD;

    public enum States
    {
        normal,
        fly,
        snake
    }

    public States currentState;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        gc = FindObjectOfType<GameController>();

        animator = GetComponent<Animator>();

        currentState = States.normal;
        isNormal = true;
    }

    private void Update()
    {
        // animator setup
        if(animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
            animator.SetBool("isFly", isFly);
            animator.SetBool("isNormal", isNormal);
            animator.SetBool("isSnake", isSnake);
        }
        
        // swap too fly
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.Q))
        {
            if (!wasFly && !isSnake && !isFly)
                CreateFlyState();
        }

        // swap too snake
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.E))
        {
            if (!wasSnake && !isFly && !isSnake)
                CreateSnakeState();
        }

        // swap too normal state based on a cooldown
        if (isFly && flyCD <= 0)
        {
            isFly = false;
            wasFly = true;

            ReturnToNormalState();
        }
        else
        {
            flyCD -= Time.deltaTime;
        }

        if (isSnake && snakeCD <= 0)
        {
            isSnake = false;
            wasSnake = true;

            ReturnToNormalState();
        }
        else
        {
            snakeCD -= Time.deltaTime;
        }

    }

    // Switch to fly state
    void CreateFlyState()
    {
        currentState = States.fly;
        isFly = true;
        isNormal = false;

        gc.UpdateUI(1);

        flyCD = CooldownTime;
        //StartCoroutine(FlyCooldown());
    }

    // Switch to snake state
    void CreateSnakeState()
    {
        currentState = States.snake;
        isSnake = true;
        isNormal = false;

        gc.UpdateUI(2);

        snakeCD = CooldownTime-1f;

        //StartCoroutine(SnakeCooldown());
    }

    void ReturnToNormalState()
    {
        currentState = States.normal;
        isNormal = true;
    }

    // refresh player and all states
    public void Refresh()
    {
        ReturnToNormalState();

        wasFly = false;
        wasSnake = false;

        isFly = false;
        isSnake = false;

        if(animator != null)
        {
            animator.SetFloat("Speed", 0);

            animator.SetBool("isFly", isFly);
            animator.SetBool("isNormal", isNormal);
            animator.SetBool("isSnake", isSnake);
        } 
    }
}
