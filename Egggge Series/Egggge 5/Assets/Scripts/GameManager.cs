using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player playerOne;
    public Player playerTwo;
    public MainStageUI mainStageUI;
    public GameStateHandler gameStateHandler;

    void Start()
    {
        gameStateHandler = GetComponent<GameStateHandler>();
        playerOne = GameObject.Find("PlayerOne").GetComponent<Player>();
        playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();
        mainStageUI = GetComponent<MainStageUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (playerOne.health <= 0 || playerTwo.health <= 0)
        {
            gameStateHandler.gameState = GameStateHandler.GameState.GameOver;
            mainStageUI.gameOverPanel.SetActive(true);
        }
    }
}
