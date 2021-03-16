using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_FootSoldier : MonoBehaviour
{
    public float attackPeriod;
    float lastAttack;
    public Collider2D target;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Area").GetComponent<SCR_Area>().spawn)
        {
            if ((target) && (Time.time > lastAttack + attackPeriod))
            {
                target.GetComponent<SET_Params>().Damage(GetComponent<SET_Params>().power);
                lastAttack = Time.time;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = other;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
