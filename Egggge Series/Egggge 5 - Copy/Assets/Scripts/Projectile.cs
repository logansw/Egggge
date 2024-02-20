using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Vector2 dir;
    protected Player player;
    [SerializeField] protected Rigidbody2D rb;

    protected float speed = 10f;
    [HideInInspector] public int damage;

    public void Initialize(Player player)
    {
        this.player = player;
        transform.position = player.transform.position;

        if (player.dir == Player.Direction.Left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            dir = new Vector2(-speed, 0);
            transform.position += new Vector3(-1.2f, 0, 0);
        } 
        else {
            dir = new Vector2(speed, 0);
            transform.position += new Vector3(1.2f, 0, 0);
        }
    }

    private void Update()
    {
        rb.velocity = dir;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
