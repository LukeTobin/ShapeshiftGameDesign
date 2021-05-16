using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to be attached to any object which should kill a player
public class KillPlayer : MonoBehaviour
{
    public GameObject respwanPoint;
    public GameObject refresh;
    GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // if the player collides with this object, reset them back to the last reset point
            collision.transform.position = respwanPoint.transform.position;
            gc.RefreshAll();

            if (refresh != null)
                refresh.SetActive(true);
        }
    }
}
