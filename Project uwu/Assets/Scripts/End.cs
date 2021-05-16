using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class for handling ending game
public class End : MonoBehaviour
{
    PlayerController player;
    public GameObject endScreen;
    bool canExit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        endScreen.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // when the end screen is triggered, reset players movement and show end menu
        player.moveSpeed = 0;
        endScreen.SetActive(true);
        canExit = true;
    }
    private void Update()
    {
        if (canExit)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Application.Quit(); // exit game
            }
        }
    }
}
