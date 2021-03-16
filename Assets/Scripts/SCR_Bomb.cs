using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Bomb : MonoBehaviour
{
    float power;
    //public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        power = GetComponent<SET_Params>().power;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Area").GetComponent<SCR_Area>().spawn) GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<SET_Params>().Damage(power);
            Destroy(gameObject);
     //       Instantiate(other, GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
