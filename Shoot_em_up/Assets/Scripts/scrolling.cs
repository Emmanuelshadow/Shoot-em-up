using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public Renderer rend;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(rend.material.GetTextureOffset("_MainTex").x <= 1)
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(rend.material.mainTextureOffset.x + speed * Time.deltaTime, 0));
        }

        else
        {
            rend.material.SetTextureOffset("_MainTex", new Vector2(-1, 0));
        }
        
    }
}
