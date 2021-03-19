using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Zombie : SCR_Enemy
{
    public float attackPeriod;
    float lastAttack;
    public Collider2D target;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (enable)
        {
            if ((target) && (Time.time > lastAttack + attackPeriod))
            {
                target.GetComponent<SCR_Player>().Damage(power);
                lastAttack = Time.time;
            }
        }
        else
        {
            Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = other;
            Stop();
        }
    }
}
