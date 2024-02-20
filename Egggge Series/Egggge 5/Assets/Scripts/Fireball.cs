using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    private void Awake()
    {
        damage = 2;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Player player = collider.gameObject.GetComponent<Player>();
            if (player.isBurning)
            {
                player.health -= damage;
            }
            player.Burn();
            Destroy(this.gameObject);
        }
    }
}
