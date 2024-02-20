using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public Chicken chicken;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private GameStateHandler gameStateHandler;
    private SpriteRenderer spriteRenderer;

    // KeyCode Controls
    public KeyCode jumpKey;
    public KeyCode fireA;
    public KeyCode fireB;
    public KeyCode fallKey;

    // Stat Tracking
    public int health;
    public int jumpsLeft;
    public bool isGrounded;

    // Direction
    public enum Direction { Left, Right };
    public Direction dir;

    // Tutorial Checks
    private bool jumpCheck;
    private bool eggCheck;
    private bool attackCheck;
    private bool fallCheck;
    public bool allCheck;

    // Status Effects
    public bool isBurning;
    private float burnTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameStateHandler = GameObject.Find("GameManager").GetComponent<GameStateHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        health = chicken.maxHealth;
        jumpsLeft = chicken.jumpCap;
    }

    void Update()
    {
        if (!gameStateHandler.gameState.Equals(GameStateHandler.GameState.GameOver))
        {
            ReadInput();
            animator.SetBool("isGrounded", isGrounded);
            animator.SetFloat("velocity", rb.velocity.y);
        }
        if (!allCheck)
        {
            allCheck = jumpCheck && eggCheck && attackCheck && fallCheck;       // Set allCheck to true once everything has been checked
        }

        burnTime -= Time.deltaTime;
        if (burnTime < 0)
        {
            isBurning = false;
            spriteRenderer.color = Color.white;
        }
    }

    private void ReadInput()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
            jumpCheck = true;
            Debug.Log(name + " jump check: " + jumpCheck);
        }

        if (!isGrounded && Input.GetKeyDown(fallKey))
        {
            FastFall();
            fallCheck = true;
            Debug.Log(name + " fall check: " + fallCheck);
        }

        if (chicken.launcherA.reloaded && chicken.launcherB.reloaded)
        {
            if (Input.GetKey(fireA))
            {
                chicken.launcherA.Shoot();
                attackCheck = true;
                Debug.Log(name + " attack check: " + attackCheck);
            }
            if (Input.GetKey(fireB))
            {
                chicken.launcherB.Shoot();
                eggCheck = true;
                Debug.Log(name + " egg check: " + eggCheck);
            }
        }
    }

    private void Jump()
    {
        isGrounded = false;
        if (jumpsLeft > 0)
        {
            rb.velocity = new Vector2(0, chicken.jumpForce);
            jumpsLeft--;
            animator.SetTrigger("jump");
        }
    }
    private void FastFall()
    {
        jumpsLeft = 0;
        rb.velocity = new Vector2(0, -20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameStateHandler.gameState.Equals(GameStateHandler.GameState.Playing))
        {
            if (collision.tag.Equals("Projectile"))      // Make sure all projectiles are tagged as projectiles!
            {
                Projectile projectile = collision.gameObject.GetComponent<Projectile>();
                health -= projectile.damage;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            isGrounded = true;
            jumpsLeft = chicken.jumpCap;
        }
    }

    public void Burn()
    {
        isBurning = true;
        burnTime = 2f;
        spriteRenderer.color = Color.red;
    }
}