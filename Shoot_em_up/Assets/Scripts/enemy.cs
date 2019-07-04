using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int life = 30;
    public int StartLife;
    public float speed;
    public int Damage;
    public enums.BonusType bonus;


    private void Awake()
    {
      
    }

    private void Start()
    {
        StartLife = life;
    }
    public void takeDamage(int damage)
    {
        life -= damage;
    }

    private void Update()
    {

    
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (life <= 0 && transform.position.x > -11)
        {
            if (bonus != 0)
            {
                GameObject b = Pool.Pooler.GetObject("Bonus" + bonus.ToString());
                b.transform.position = transform.position;
                b.SetActive(true);

            }
            initialize();
        }
        if (transform.position.x < -12)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().takeDamage(5);
            initialize();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerMovement>().takeDamage(Damage);
            musicManager.music.PlayExplosion();
            initialize();
        }
    }

    public void initialize()
    {
        life = StartLife;

        gameObject.SetActive(false);
    }

  
}