using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Enemy : SCR_Character
{
    public Vector3 velocity;
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        float Rad = angle / 180 * Mathf.PI;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(Rad), speed * Mathf.Sin(Rad));
        velocity = GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();   
    }

    public void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
