using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Character : MonoBehaviour
{
    public float health;
    public float speed;
    public float power;
    public float point;
    public float hp;
    public float angle;
    public SpriteRenderer Heart;
    public Transform Body;
    public bool enable;
    public SCR_Area area;


    protected virtual void Start() 
    {
        area = GameObject.Find("Area").GetComponent<SCR_Area>();
        if (Body) Body.rotation = Quaternion.Euler(0, 0, angle);
        if (Heart) Heart.size = new Vector2(0.6f, 0.2f);
        hp = health;
    }
    public virtual void Update()
    {
        enable = area.spawn;
        if (Heart) Heart.size = new Vector2(0.6f * hp / health, 0.2f);
    }

    public void Damage(float value)
    {
        hp -= Mathf.Min(hp, value);
        if (hp == 0) Destroy(gameObject);
    }
}

