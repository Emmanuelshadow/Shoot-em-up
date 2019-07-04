using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveAura : MonoBehaviour
{
    public int damage;
    public float speed;
    public LayerMask whatIsEnemy;
    public float rad;
    public float radMax;
    public float max;
    public CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1, 1);
        col = GetComponent<CircleCollider2D>();
        col.radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < max && transform.localScale.x < max)
        {
            if(rad < radMax)
            {
                rad += Time.deltaTime;
            }
            
            transform.localScale = new Vector2(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime) ;
        }
        if (transform.localScale.x >= max && transform.localScale.x >= max)
        {
            gameObject.SetActive(false);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
            Collider2D[] enemyToDestroy = Physics2D.OverlapCircleAll(transform.position, rad, whatIsEnemy);
            
            for(int i = 0; i < enemyToDestroy.Length; i++)
            {
                enemyToDestroy[i].GetComponent<enemy>().takeDamage(damage);
            }
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
 
            Collider2D[] enemyToDestroy = Physics2D.OverlapCircleAll(transform.position, rad, whatIsEnemy);

            for (int i = 0; i < enemyToDestroy.Length; i++)
            {
                enemyToDestroy[i].GetComponent<enemy>().takeDamage(damage);
            }

    }
    private void OnDisable()
    {
        transform.localScale = new Vector2(1, 1);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rad);
    }


}
