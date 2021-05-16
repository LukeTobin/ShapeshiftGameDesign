using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reset player and refresh all variables
public class Refresh : MonoBehaviour
{
    GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gc.RefreshAll();
            gameObject.SetActive(false);
        }
    }
}
