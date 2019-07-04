using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public int Count;
    public int InitialCount;
    public float lifeTime;
    public float StartLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        InitialCount = Count;
        StartLifeTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(Count <= 0 || lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void Hurt(int damage)
    {
        Count -= damage;
    }
    public void Initialize()
    {
        Count = InitialCount;
        lifeTime = StartLifeTime;
    }
}
