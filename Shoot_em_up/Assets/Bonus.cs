using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public enums.BonusType bonus;
    public float LifeTime = 5f;
    float StartLifeTime;

    private void Start()
    {
        StartLifeTime = LifeTime;
    }

    private void Update()
    {
        LifeTime -= Time.deltaTime;

        if(LifeTime <= 0)
        {
            LifeTime = StartLifeTime;
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            musicManager.music.PlayPowerUps();
            GlobalEventNotifier.OnPickupABonus(bonus);
            gameObject.SetActive(false);
        }
    }
}
