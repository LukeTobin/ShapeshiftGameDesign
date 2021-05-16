using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allow music to play through scenes
public class Music : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
