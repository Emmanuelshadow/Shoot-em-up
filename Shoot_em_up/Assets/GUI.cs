using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public Text Lives;
    public int live;
    playerMovement player;


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        if (player != null)
        {
            live = player.life;
        }

        if (live <= 0)
        {
            GameManager.GM.ActiveUi("GameOverMenu");
        }
        
        Lives.text = live.ToString();
    }
}
