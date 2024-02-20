using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    private Player player;
    [SerializeField] string playerName;
    public GameStateHandler gameStateHandler;

    private void Start()
    {
        player = GameObject.Find(playerName).GetComponent<Player>();
        gameStateHandler = GameObject.Find("GameManager").GetComponent<GameStateHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        if (collision.name == "Projectile_Egg(Clone)" && gameStateHandler.gameState.Equals(GameStateHandler.GameState.Playing))
        {
            player.health--;
        }
        if (collision.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        } else
        {
            Debug.Log("Your projectile is not tagged as a projectile!");    // Helper debug code
        }
    }
}
