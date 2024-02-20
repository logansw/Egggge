using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

    [SerializeField] KeyCode jumpButton;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }
}
