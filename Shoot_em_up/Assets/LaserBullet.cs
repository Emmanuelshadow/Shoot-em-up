using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public float speed = 12;
    public float lifeTime = 5;
    public float startLifeTime;
    public int damage;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        startLifeTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("Laser").transform.position.y);
        line.SetPosition(0, GameObject.FindGameObjectWithTag("Laser").transform.position);
        line.SetPosition(1, transform.position);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            off();
        }

        

    }

    public void off()
    {
        line.SetPosition(0, GameObject.FindGameObjectWithTag("Laser").transform.position);
        line.SetPosition(1, GameObject.FindGameObjectWithTag("Laser").transform.position);
        lifeTime = startLifeTime;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            col.gameObject.GetComponent<enemy>().takeDamage(damage);
            off();
        }
    }
}
