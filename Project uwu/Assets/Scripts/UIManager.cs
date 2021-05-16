using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class for handling UI
public class UIManager : MonoBehaviour
{

    public Image fly;
    public Image snake;

    Color tempFly;
    Color tempSnake;

    Color originalFly;
    Color originalSnake;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // set color and sprites
        tempFly = fly.color;
        tempSnake = snake.color;

        originalFly = tempFly;
        originalSnake = tempSnake;

        tempFly.a = 0.5f;
        tempSnake.a = 0.5f;
    }

    public void Cooldown(int type)
    {
        // switch color
        switch (type)
        {
            case 1:
                fly.color = tempFly;
                break;
            case 2:
                snake.color = tempSnake;
                break;
            default:
                break;
        }       
    }

    public void Refresh()
    {
        fly.color = originalFly;
        snake.color = originalSnake;
    }
}
