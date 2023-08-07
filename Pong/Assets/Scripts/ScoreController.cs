using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2
}

public class ScoreController: MonoBehaviour
{
    public List<ScoreSetup> scores;
    public SO_Score maxScore;

    private int maxScoreToWin;

    public void Start()
    {
        ResetScores();
    }

    public void SetPoints(PlayerType type)
    {
        var setup = scores.Find(x => x.playerType == type);

        if(setup != null)
        {
            setup.score.value += 1;

            CheckScore(setup);          
        }      
    }

    private void CheckScore(ScoreSetup setup)
    {
        if(setup.score.value >= maxScoreToWin)
        {
            GameManager.Instance.uiController.SetWinner(setup.playerType.ToString(), true);

            GameManager.Instance.StartGameOver();

            return;
        }

        GameManager.Instance.uiController.SetScoreText(setup.playerType, setup.score.value);
    }

    public void ResetScores()
    {
        foreach(ScoreSetup setup in scores)
        {
            setup.score.value = 0;
        }

        maxScoreToWin = maxScore.value;
    }
}

[System.Serializable]
public class ScoreSetup
{
    public SO_Score score;
    public PlayerType playerType;
}
