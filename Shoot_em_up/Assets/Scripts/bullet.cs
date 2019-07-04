using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 12;
    public float lifeTime = 5;
    public float StartLifetime;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        StartLifetime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            lifeTime = StartLifetime;
            gameObject.SetActive(false);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            musicManager.music.PlayExplosion();
            col.gameObject.GetComponent<enemy>().takeDamage(damage);
            lifeTime = StartLifetime;
            gameObject.SetActive(false);
        }
    }


}
