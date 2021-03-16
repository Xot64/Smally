using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tank : MonoBehaviour
{
    public float shootPeriod;
    public GameObject bullet;
    public float bulletSpeed;

    float startC;
    float X, Y;
    float lastShoot;
    // Start is called before the first frame update

    float dist()
    {
        float x = GetComponent<Transform>().position.x;
        float y = GetComponent<Transform>().position.y;
        return Mathf.Sqrt(x * x + y * y);
    }

    void Start()
    {
        startC = dist();
    }

    // Update is called once per frame
    void Update()
    {
        if ((dist() <= startC / 2.0f) || (!GameObject.Find("Area").GetComponent<SCR_Area>().spawn))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if ((Time.time > lastShoot + shootPeriod) && (GameObject.Find("Area").GetComponent<SCR_Area>().spawn))
            {
                lastShoot = Time.time;
                GameObject S = Instantiate(bullet, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                S.GetComponent<SCR_Arrow>().angle = GetComponent<SET_Params>().angle;
                S.GetComponent<SCR_Arrow>().speed = bulletSpeed;
                S.GetComponent<SET_Params>().power = GetComponent<SET_Params>().power;
                
            }
        }
    }
}
