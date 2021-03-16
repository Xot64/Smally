using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Arrow : MonoBehaviour
{
    public float speed;
    public float angle;
    public bool fromMe;
    // Start is called before the first frame update
    void Start()
    {
        float Rad = angle / 180 * Mathf.PI;
        GetComponent<Rigidbody2D>().velocity = new Vector2 (speed*Mathf.Cos(Rad), speed * Mathf.Sin(Rad));
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((fromMe) && (other.tag == "Enemy")) || ((!fromMe) && (other.tag == "Player")))
        {
            if (other.GetComponent<SET_Params>().hp <= GetComponent<SET_Params>().power)
            {
                GameObject.Find("Player").GetComponent<SET_Params>().point += other.GetComponent<SET_Params>().point;
            }
            other.GetComponent<SET_Params>().Damage(GetComponent<SET_Params>().power);
            Destroy(gameObject);
        }
    }
}
