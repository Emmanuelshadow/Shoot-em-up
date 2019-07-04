using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 7;
    public float lifeTime = 5;
    public float StartLifetime;
    public float InitialSpeed;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        StartLifetime = lifeTime;
        InitialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(lifeTime <= 0 || transform.position.x < -12)
        {
            speed = 0;
            desactive();
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            musicManager.music.PlayPlayerHurt();
            col.gameObject.GetComponent<playerMovement>().takeDamage(damage);
            desactive();

        }
        if (col.gameObject.CompareTag("shield"))
        {
            col.gameObject.GetComponent<shield>().Hurt(damage);
            desactive();
        }
        if (col.gameObject.CompareTag("destructiveAura"))
        {
            desactive();
        }
    }

    public void desactive()
    {
        lifeTime = StartLifetime;
        speed = InitialSpeed;
        gameObject.SetActive(false);
    }
}
