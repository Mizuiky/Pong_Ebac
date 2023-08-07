using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;

    public ScoreController scoreController;

    public BallController ball;

    public static GameManager Instance;

    public event Action onResetGame;

    public event Action onGameOver;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<GameManager>();
        }
        else
        {
            Destroy(Instance.gameObject);
        }    
    }

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        uiController.SetWinner("", false);

        scoreController.ResetScores();

        onResetGame?.Invoke();

        ball._isGameRunning = true;

        ball.ResetPosition();
    }

    public void StartGameOver()
    {
        onGameOver?.Invoke();
    }
}
