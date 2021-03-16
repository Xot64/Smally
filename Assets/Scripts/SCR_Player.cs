using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Player : MonoBehaviour
{
    public float shootPeriod;
    public float shootSpeed;
    float oldShoot;
    public GameObject arrow;
    public float winPoint;
    public GameObject text;
    public GameObject text1;
    float t;


    Transform Me;
    
    // Start is called before the first frame update
    void Start()
    {
        text1.GetComponent<Text>().text = "";
        Me = GetComponent<SET_Params>().Body.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
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
            S.GetComponent<SET_Params>().power = GetComponent<SET_Params>().power;
        }
        text.GetComponent<Text>().text = GetComponent<SET_Params>().point.ToString() + "/" + winPoint.ToString();
        if (GetComponent<SET_Params>().point >= winPoint)
        {
            GameObject.Find("Area").GetComponent<SCR_Area>().StopSpawn();
            text1.GetComponent<Text>().color = Color.green;
            text1.GetComponent<Text>().text = "!!!YOU ARE WIN!!!";

            GameObject.Find("Area").GetComponent<SCR_Area>().end = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
    private void OnDestroy()
    {
        GameObject.Find("Area").GetComponent<SCR_Area>().StopSpawn();
        text1.GetComponent<Text>().color = Color.red;
        text1.GetComponent<Text>().text = "!!!YOU ARE DEAD!!!";
        GameObject.Find("Area").GetComponent<SCR_Area>().end = true;
    }

    public void addPoints (float points)
    {
        GetComponent<SET_Params>().point += points;
        
    }
}
