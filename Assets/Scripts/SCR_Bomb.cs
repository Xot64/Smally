using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Bomb : SCR_Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!GameObject.Find("Area").GetComponent<SCR_Area>().spawn) Stop();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<SCR_Player>().Damage(power);
            Destroy(gameObject);
        }
    }
}
