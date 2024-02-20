using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int speed;
    private int damage;
    private Chicken chicken;
    private Vector2 dir;

    private void Start()
    {
        if (chicken.transform.position.x > 0)
        {
            speed = -speed;
        }
        dir = new Vector2(speed, 0);
    }
    /*
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }*/
}
