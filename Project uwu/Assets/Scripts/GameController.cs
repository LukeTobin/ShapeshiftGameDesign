using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UIManager uim;
    PlayerController player;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        uim = FindObjectOfType<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void UpdateUI(int type)
    {
        uim.Cooldown(type); // put shapeshift form on cooldown 
    }

    // refresh all player ui
    public void RefreshAll()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        uim.Refresh();
        player.Refresh();
    }
}
