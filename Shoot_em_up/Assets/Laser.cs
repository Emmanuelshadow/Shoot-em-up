using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Arme
{
    public GameObject bPrefab;
    public float Cadence;



    private void Start()
    {
        cadence = Cadence;
        ObjectTag = bPrefab.tag;
        pos = transform.position;
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    private void Update()
    {
        pos = transform.position;
    }
}
