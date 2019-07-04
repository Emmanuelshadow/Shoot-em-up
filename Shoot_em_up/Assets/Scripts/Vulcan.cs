using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulcan : Arme
{
    public Arme pos1;
    public Arme pos2;
    public float Cadence;
    // Start is called before the first frame update
    private void Start()
    {
        cadence = Cadence;
    }

    public override void Shoot()
    {
            pos1.Shoot();
            pos2.Shoot();
        
    }
}
