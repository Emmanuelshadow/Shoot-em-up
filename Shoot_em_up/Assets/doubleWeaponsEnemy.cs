using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleWeaponsEnemy : Arme
{
    public float cad;
    public EnemyWeapon w1;
    public EnemyWeapon w2;
    // Start is called before the first frame update
    void Start()
    {
        w1.Cadence = cad;
        w2.Cadence = cad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
