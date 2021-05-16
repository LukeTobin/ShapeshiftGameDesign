using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// load the next scene
public class NewScene : MonoBehaviour
{
    public string scene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(scene);
    }
}
