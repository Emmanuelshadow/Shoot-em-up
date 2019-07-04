using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    int i = 0;
    public List<GameObject> ActiveEnemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if(i < enemiesToSpawn.Length)
        {
            int rand = Random.Range(0, spawnPoints.Length);

            GameObject e = Pool.Pooler.GetObject(enemiesToSpawn[i].tag);
            e.transform.position = spawnPoints[rand].position;
            if (e.transform.position.x == spawnPoints[rand].position.x && e.transform.position.y == spawnPoints[rand].position.y)
            {
                e.SetActive(true);
                ActiveEnemy.Add(e);
            }
            i++;
        }
    }

    private void Update()
    {
        for(int j = 0; j < ActiveEnemy.Count; j++)
        {
            if (!ActiveEnemy[j].activeInHierarchy)
            {
                ActiveEnemy.Remove(ActiveEnemy[j]);
            }
        }

        if(i == enemiesToSpawn.Length && ActiveEnemy.Count == 0 && GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().life > 0)
        {
            GameManager.GM.ActiveUi("Win");
        }
    }
}
