using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour
{
    public Transform Trans;
    public float ampli = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float Y = Mathf.Sin(Time.time) * ampli ;
        Trans.position = new Vector2(Trans.position.x, Y);
    }
}
