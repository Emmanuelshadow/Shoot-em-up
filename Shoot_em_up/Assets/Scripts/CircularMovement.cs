using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public Transform Trans;
    public float ampli;
    public float speed;
    float centreX = 14;
    float centreY;
    // Start is called before the first frame update
    private void OnDisable()
    {
        centreX = 14;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        float Y = Mathf.Sin(Time.time) * ampli;
        float X = Mathf.Cos(Time.time) * ampli;
        centreX += Time.fixedDeltaTime * speed;
        centreY += 0;
        Trans.position = new Vector2( centreX + X, Y);
    }
}
