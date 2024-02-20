using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    private const int BURN_TIMER = 2;
    
    public float burnTime;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        burnTime -= Time.deltaTime;
        if (burnTime > 0)
        {
            spriteRenderer.color = Color.red;
        } else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void Burn()
    {
        burnTime = BURN_TIMER;
    }
}
