using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekineticBall : Projectile
{
    private float followSpeed = 3f;

    private void Awake()
    {
        damage = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = dir;      // This should really be a call to the function on the base class
        Destroy(gameObject, 3);
        if (player.transform.position.y > transform.position.y)
        {
            rb.velocity = rb.velocity + new Vector2(0, followSpeed);
        } else if (player.transform.position.y < transform.position.y)
        {
            rb.velocity = rb.velocity + new Vector2(0, -followSpeed);
        }
    }
}
