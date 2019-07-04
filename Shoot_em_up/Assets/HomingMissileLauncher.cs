using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileLauncher : Arme
{
    public GameObject bullet;
    public float Cadence;
    // Start is called before the first frame update
    void Start()
    {
       
        cadence = Cadence;
        ObjectTag = bullet.tag;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
    }

    public override void Shoot()
    {
        ObjectTag = bullet.tag;
        base.Shoot();
    }
}
