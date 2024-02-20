using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private int health;
    private int jumpCap;

    public void Start()
    {
        health = 12;
        jumpCap = 2;
    }

    /*
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            health -= projectile.Damage;
            Debug.Log(health);
        }
    }*/
}
