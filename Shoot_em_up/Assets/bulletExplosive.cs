using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletExplosive : MonoBehaviour
{
    public float Life;
    public float StartLife;
    public float explosionDuree;
    public float InitialExplosionDuree;
    public Sprite explosion;
    public Sprite defaultSprite;
    public Color explosionColor;
    public float speed;
    public float Initialspeed;
    public float scaleMultiplier;
    public float max;
    public float rad;
    public int damage;
    public LayerMask whatIsEnemy;
    bool explose = false;
    public Vector2 startScale;
    // Start is called before the first frame update
    void Start()
    {
        StartLife = Life;
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<CircleCollider2D>().enabled = false;
        Initialspeed = speed;
        InitialExplosionDuree = explosionDuree;
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if (Life > 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

        }
        else if (Life <= 0)
        {
            Explose();
            speed = 0;
        }
        if (explose )
        {
            if(transform.localScale.x < max && transform.localScale.y < max)
            {
                transform.localScale = new Vector2(transform.localScale.x + scaleMultiplier * Time.deltaTime, transform.localScale.y + scaleMultiplier * Time.deltaTime);

            }
            explosionDuree -= Time.deltaTime;

        }
        if(explosionDuree <= 0)
        {
            inititialize();
        }



    }

    void Explose() {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sprite = explosion;
        GetComponent<SpriteRenderer>().color = explosionColor;

        explose = true;
        explosionDuree -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (explose)
        {
            musicManager.music.PlayExplosion();
            GetComponent<CircleCollider2D>().enabled = false;
            Collider2D[] toDestroy = Physics2D.OverlapCircleAll(transform.position, rad, whatIsEnemy);

            for(int i = 0; i < toDestroy.Length; i++)
            {
                toDestroy[i].gameObject.GetComponent<enemy>().takeDamage(damage);
                Debug.Log(toDestroy[i].gameObject.GetComponent<enemy>().life);

                
            }
            inititialize();
        }
    }

    void inititialize()
    {
        Life = StartLife;
        explose = false;
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
        speed = Initialspeed;
        explosionDuree = InitialExplosionDuree;
        transform.localScale = startScale;
        GetComponent<CircleCollider2D>().enabled = false;
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rad);
    }

    //commentaire pour te montrer les modifications sur github
}
