using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Projectile
{
    // Start is called before the first frame update
    void Awake()
    {
        speed = 10f;
        damage = 0;
    }
}
