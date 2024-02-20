using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Projectile
{
    private void Awake()
    {
        speed = 10f;
        damage = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") || collision.tag.Equals("Projectile"))
        {
            Destroy(this.gameObject);
        }
    }
}
