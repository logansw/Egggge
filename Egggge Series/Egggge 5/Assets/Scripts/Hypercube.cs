using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypercube : Projectile
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = dir;
        Destroy(gameObject, 3);
        if (transform.position.x > -1 && transform.position.x < 1)
        {
            spriteRenderer.enabled = true;
        }
    }
}
