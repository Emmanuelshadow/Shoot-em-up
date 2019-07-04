using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Arme
{
    public float Cadence;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        cadence = Cadence;
        ObjectTag = b.tag;
        bulletPrefab = b;
        pos = transform.position;
    }

    public override void Shoot()
    {
        base.Shoot();
    }
    private void Update()
    {
        pos = transform.position;
        if (CanShoot())
        {
            Shoot();
        }
    }

  
}
