using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tank : SCR_Enemy
{

    float startC;
    float X, Y;

    public float shootPeriod;
    public GameObject bullet;
    public float bulletSpeed;
    float lastShoot;
    // Start is called before the first frame update

    float dist()
    {
        float x = GetComponent<Transform>().position.x;
        float y = GetComponent<Transform>().position.y;
        return Mathf.Sqrt(x * x + y * y);
    }

    protected override void Start()
    {
        base.Start();
        startC = dist();
        lastShoot = Time.time;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if ((dist() <= startC / 2.0f) || (!GameObject.Find("Area").GetComponent<SCR_Area>().spawn))
        {
            Stop();
            if ((Time.time > lastShoot + shootPeriod) && enable)
            {
                lastShoot = Time.time;
                GameObject S = Instantiate(bullet, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
                S.GetComponent<SCR_Arrow>().angle = angle;
                S.GetComponent<SCR_Arrow>().speed = bulletSpeed;
                S.GetComponent<SCR_Character>().power = power;
            }
        }
    }
}
