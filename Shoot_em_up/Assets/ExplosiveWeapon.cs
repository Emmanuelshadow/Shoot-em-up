using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveWeapon : Arme
{

    public float Cadence;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        cadence = Cadence;
        ObjectTag = bullet.tag;
    }

    private void Update()
    {
        pos = transform.position;
    }
    public override void Shoot()
    {
        base.Shoot();
    }
}
