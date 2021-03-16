using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SET_Params : MonoBehaviour
{
    public float health;
    public float speed;
    public float power;
    public float point;
    public float hp;
    public float angle;
    public GameObject Heart;
    public GameObject Body;

    public void Damage(float value)
    {
        if (hp > value)
        {
                hp -= value;
            }
            else
            {
                hp = 0;
                Destroy(gameObject);
            }
    }
    void Start()
    {
        if (Body) Body.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle);
        if (Heart) Heart.GetComponent<SpriteRenderer>().size = new Vector2(0.6f, 0.2f);
        hp = GetComponent<SET_Params>().health;
        
    }
    private void Update()
    {
        if (Heart) Heart.GetComponent<SpriteRenderer>().size = new Vector2(0.6f * hp / health, 0.2f);
    }
}

