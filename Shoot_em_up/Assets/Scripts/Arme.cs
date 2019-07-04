using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Arme : MonoBehaviour
{

    protected GameObject bulletPrefab;
    protected float lastTime;
    protected float cadence;
    protected Vector2 pos = new Vector2();
    protected string ObjectTag;

    public AudioSource music;



    private void Start()
    {
        lastTime = cadence;
    }
    public virtual void Shoot()
    {
        
        if(CanShoot() )
        {
                

                bulletPrefab = Pool.Pooler.GetObject(ObjectTag);

                bulletPrefab.transform.position = pos;
                bulletPrefab.SetActive(true);
            if(music != null)
            {
                music.Play();
            }
            
            lastTime = Time.time;
        }
        else
        {
            return;
        }

    }
    public virtual bool CanShoot()
    {
        if (Time.time > lastTime + cadence)
        {
            return true;
        }

        return false;

    }

}
