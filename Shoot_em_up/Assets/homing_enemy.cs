using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_enemy : enemy
{
    public int damage;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<playerMovement>().takeDamage(damage);
        }
        else if (col.gameObject.CompareTag("shield"))
        {
            col.gameObject.GetComponent<shield>().Hurt(damage);
        }
    }
}
