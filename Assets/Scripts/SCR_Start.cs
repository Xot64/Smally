using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_Start : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    float t;
    private void Start()
    {
        t = Time.time;
    }
    private void Update()
    {

        if (Time.time <= t + 1)
        { 
        //LoadPar(player, "P");
            LoadPar(enemy1, "T");
            LoadPar(enemy2, "Z");
            LoadPar(enemy3, "B");
            GameObject.Find("Health_P").GetComponent<InputField>().text = player.GetComponent<SET_Params>().health.ToString();
            GameObject.Find("Power_P").GetComponent<InputField>().text = player.GetComponent<SET_Params>().power.ToString();
            GameObject.Find("Points_P").GetComponent<InputField>().text = player.GetComponent<SCR_Player>().winPoint.ToString();
        }
        
    }
    public void PlayPressed()
    {
        
        SavePar(player, "P");
        SavePar(enemy1, "T");
        SavePar(enemy2, "Z");
        SavePar(enemy3, "B");
        player.GetComponent<SET_Params>().point = 0.0f;
        player.GetComponent<SCR_Player>().winPoint = F2F("Points_P");
        //Application.LoadLevel("Game");
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private float F2F(string name)
    {
        return (float)System.Convert.ToDouble(GameObject.Find(name).GetComponent<InputField>().text);
    }
     private void SavePar (GameObject obj, string c)
    {
        obj.GetComponent<SET_Params>().health = F2F("Health_" + c);
        obj.GetComponent<SET_Params>().speed = F2F("Speed_" + c);
        obj.GetComponent<SET_Params>().power = F2F("Power_" + c);
        obj.GetComponent<SET_Params>().point = F2F("Points_" + c);
    }
    private void LoadPar(GameObject obj, string c)
    {
        GameObject.Find("Health_" + c).GetComponent<InputField>().text = obj.GetComponent<SET_Params>().health.ToString();
        GameObject.Find("Speed_" + c).GetComponent<InputField>().text = obj.GetComponent<SET_Params>().speed.ToString();
        GameObject.Find("Power_" + c).GetComponent<InputField>().text = obj.GetComponent<SET_Params>().power.ToString();
        GameObject.Find("Points_" + c).GetComponent<InputField>().text = obj.GetComponent<SET_Params>().point.ToString();
    }
}
