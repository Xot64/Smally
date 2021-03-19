using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SCR_Area : MonoBehaviour
{
    public float spawnPeriod;
    float lastSpawn;
    float X, Y, C, K;
    public bool spawn;
    public SCR_Player player;
    public GameObject zombie;
    public GameObject tank;
    public GameObject bomb;
    public bool end;
    public Text Points;
    public Text Message;
    public Text Health;

    float t;
    // Start is called before the first frame update
    void Start()
    {

        end = false;
        spawn = true;
        X = 10; //10
        Y = 6; //6
        C = Mathf.Sqrt(X * X + Y * Y);
        Message.text = ""; 
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Points.text = player.point.ToString() + "/" + player.winPoint.ToString();
            if (player.point >= player.winPoint) showMSG(true);
        }
        if ((Time.time >= lastSpawn + spawnPeriod) && (spawn))
        {
            int rndSpawn = Random.Range(0, 4);
            int LTRB = Random.Range(0,4);
            float rndPosition = Random.Range(-1.0f, 1.0f);
            Vector2 spawnPosition;
            switch (LTRB)
            {
                case 0:
                    spawnPosition.x = -X;
                    spawnPosition.y = Y * rndPosition;
                    break;
                case 1:
                    spawnPosition.x = X * rndPosition;
                    spawnPosition.y = Y;
                    break;
                case 2:
                    spawnPosition.x = X;
                    spawnPosition.y = Y * rndPosition;
                    break;
                case 3:
                    spawnPosition.x = X * rndPosition;
                    spawnPosition.y = -Y;
                    break;
                default:
                    spawnPosition.x = X;
                    spawnPosition.y = Y;
                    break;
            }

            float MPX = spawnPosition.x;
            float MPY = spawnPosition.y;
            float alpha = Mathf.Atan2(Mathf.Abs(MPY), Mathf.Abs(MPX));
            float angle = Mathf.Sign(MPY) * (Mathf.PI / 2 + Mathf.Sign(MPX) * (alpha - Mathf.PI / 2)) / Mathf.PI * 180;
            GameObject enemy;
            switch (rndSpawn)
            {
                case 2:
                    enemy = tank;
                    break;
                case 3:
                    enemy = bomb;
                    break;
                default:
                    enemy = zombie;
                    break;
            }
            GameObject S = Instantiate(enemy, spawnPosition, Quaternion.identity);
            S.GetComponent<SCR_Enemy>().angle = 180 + angle;
            lastSpawn = Time.time;   
        }
        if (!end) t = Time.time;
        if ((end) && (Time.time > t + 3))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    public void StopSpawn()
    {
        spawn = false;
    }

    public void showMSG(bool win)
    {
        StopSpawn();
        Health.text = "Dead";
        if (win)
        {
            Message.color = Color.green;
            Message.text = "!!!YOU ARE WIN!!!";
        }
        else
        {
            Message.color = Color.red;
            Message.text = "!!!YOU LOSE!!!";
        }
       end = true;
    }
}
