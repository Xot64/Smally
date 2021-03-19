using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Arrow : SCR_Character
{
    public bool fromMe;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        float Rad = angle / 180 * Mathf.PI;
        GetComponent<Rigidbody2D>().velocity = new Vector2 (speed*Mathf.Cos(Rad), speed * Mathf.Sin(Rad));
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((fromMe) && (other.tag == "Enemy")) || ((!fromMe) && (other.tag == "Player")))
        {
            if (other.GetComponent<SCR_Character>().hp <= power)
            {
                GameObject.Find("Player").GetComponent<SCR_Player>().addPoints(other.GetComponent<SCR_Character>().point);
            }
            other.GetComponent<SCR_Character>().Damage(power);
            Destroy(gameObject);
        }
    }
}
