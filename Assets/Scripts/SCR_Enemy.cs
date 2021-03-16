using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        float Rad = GetComponent<SET_Params>().angle / 180 * Mathf.PI;
        float speed = GetComponent<SET_Params>().speed;
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(Rad), speed * Mathf.Sin(Rad));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
