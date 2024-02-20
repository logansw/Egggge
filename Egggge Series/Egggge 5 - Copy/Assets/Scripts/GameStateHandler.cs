using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public GameState gameState;
    private Player playerOne;
    private Player playerTwo;

    public enum GameState
    {
        WaitingForStart,
        Playing,
        GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();
        playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();
        gameState = GameState.WaitingForStart;
    }

    private void Update()
    {
        if (playerOne.allCheck && playerTwo.allCheck && gameState != GameState.GameOver)
        {
            gameState = GameState.Playing;
        }
    }
}
