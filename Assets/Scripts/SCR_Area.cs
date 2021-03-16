using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SCR_Area : MonoBehaviour
{
    public float spawnPeriod;
    float lastSpawn;
    float X, Y, C, K;
    public bool spawn;
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject Win;
    public GameObject Dead;
    public bool end;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        end = false;
        spawn = true;
        X = 10; //10
        Y = 6; //6
        C = Mathf.Sqrt(X * X + Y * Y);
    //    Instantiate(player, new Vector2(0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
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
                case 1:
                    enemy = enemy1;
                    break;
                case 2:
                    enemy = enemy2;
                    break;
                case 3:
                    enemy = enemy3;
                    break;
                default:
                    enemy = enemy1;
                    break;
            }
            GameObject S = Instantiate(enemy, spawnPosition, Quaternion.identity);
            S.GetComponent<SET_Params>().angle = 180 + angle;
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

    public IEnumerator showMSG(bool win)
    {
        GameObject S = Instantiate((win ? Win : Dead), GetComponent<Transform>().position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(S);
    }
}
