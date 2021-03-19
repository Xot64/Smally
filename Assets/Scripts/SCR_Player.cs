using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Player : SCR_Character
{
    public float shootPeriod;
    public float shootSpeed;
    float oldShoot;
    public GameObject arrow;
    public float winPoint;
    float t;
    

    Transform Me;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        area = GameObject.Find("Area").GetComponent<SCR_Area>();
        Me = Body.GetComponent<Transform>();
    }

    // Update is called once per frame
    public override void Update()
    {
        area.Health.text = hp.ToString();
        base.Update();
        //Слежка за курсором
        Vector3 MPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float MPX = MPos.x;   
        float MPY = MPos.y;
        float alpha = Mathf.Atan2(Mathf.Abs(MPY), Mathf.Abs(MPX));
        float angle = Mathf.Sign(MPY) * (Mathf.PI / 2 + Mathf.Sign(MPX) * (alpha - Mathf.PI / 2)) / Mathf.PI * 180;
        Me.rotation = Quaternion.Euler(0,0,angle);
        //Стрельба
        if ((Time.time > oldShoot + shootPeriod) && (Input.GetButton("Fire1")))
        {
            oldShoot = Time.time;
            GameObject S = Instantiate(arrow, Me.position, Quaternion.identity);
            S.GetComponent<SCR_Arrow>().angle = angle;
            S.GetComponent<SCR_Arrow>().speed = shootSpeed;
            S.GetComponent<SCR_Character>().power = power;
        }
        
    }

    private void OnDestroy()
    {
        
        area.showMSG(false);
    }

    public void addPoints (float points)
    {
        point += points;
    }
}
