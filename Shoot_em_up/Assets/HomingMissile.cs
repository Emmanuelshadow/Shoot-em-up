using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 12;
    public float lifeTime = 5;
    public float StartLifetime;
    public float rotateSpeed;
    public int damage;
    List<GameObject> enemies = new List<GameObject>();
    public Transform targetPos;
    public Transform playerPos;
    public GameObject[] typeOfEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartLifetime = lifeTime;
        
        
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        
    }
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < typeOfEnemy.Length; i++)
        {
            AddEnemyToFollow(typeOfEnemy[i].tag);
        }
        if (enemies.Count > 0)
        {
            targetPos = GetClosestEnemy(enemies, playerPos);
        }
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            desactive();
        }
        if (enemies.Count <= 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);


        }

        if (transform.position == targetPos.position)
        {
            desactive();
        }

    }

    private void FixedUpdate()
    {
        if(enemies.Count > 0)
        {
            Vector2 direction = (Vector2)targetPos.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            
        }
     
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            musicManager.music.PlayExplosion();
            col.gameObject.GetComponent<enemy>().takeDamage(damage);
            desactive();
        }
    }

    public Transform GetClosestEnemy(List<GameObject> enemiesList, Transform player)
    {
        GameObject closest = null;
        float closestDistance = 0f;

        foreach(var enemy in enemiesList)
        {
            var distance = Vector3.Distance(player.position, enemy.transform.position);
            if(closest == null || closestDistance > distance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }
        
        return closest.transform;
    }
    public void AddEnemyToFollow(string enemyTag)
    {
        for(int i = 0; i < typeOfEnemy.Length; i++)
        {
            GameObject[] e = GameObject.FindGameObjectsWithTag(enemyTag);
            for(int j = 0; j < e.Length; j++)
            {
                if (e[j].activeInHierarchy)
                {
                    enemies.Add(e[j]);
                }
                
            }
        }
    }

    public void desactive()
    {
        lifeTime = StartLifetime;
        gameObject.SetActive(false);
        rb.angularVelocity = 0;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
    private void OnDisable()
    {
        enemies = new List<GameObject>();
        
    }
}
