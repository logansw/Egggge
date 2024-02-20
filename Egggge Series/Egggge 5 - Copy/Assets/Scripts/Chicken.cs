using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float jumpForce;
    public Launcher launcherA;
    public Launcher launcherB;
    public int maxHealth;
    public int jumpCap;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 5f;
    }
}
