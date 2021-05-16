using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// refresh everything in the world
public class UpdateWorld : MonoBehaviour
{
    UIManager uim;
    public GameObject refresh;

    void Start()
    {
        uim = FindObjectOfType<UIManager>();

        uim.Refresh();

        if (refresh != null)
            gameObject.SetActive(true);
    }

}
