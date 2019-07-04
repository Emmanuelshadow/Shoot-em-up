using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmePrincipal : Arme
{
    public GameObject bullet;
 
    public float Cadence;


    private void Start()
    {
        cadence = Cadence;
     
        ObjectTag = bullet.tag;
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
