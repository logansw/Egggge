using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken
{
    public int jumpCap;
    public int healthCap;
    public float reloadSpeed;

    public int currentHealth;
    public int jumpsLeft;

    public Chicken(int jumpCap, int healthCap, float reloadSpeed)
    {
        this.jumpCap = jumpCap;
        this.healthCap = healthCap;
        this.reloadSpeed = reloadSpeed;

        jumpsLeft = jumpCap;
        currentHealth = healthCap;
    }

    public void Shoot(GameObject projectile)
    {
        
    }
}
