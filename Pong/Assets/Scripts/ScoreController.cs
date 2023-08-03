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

            GameManager.Instance.uiController.SetScoreText(setup.playerType, setup.score.value);
        }      
    }

    private void ResetScores()
    {
        foreach(ScoreSetup setup in scores)
        {
            setup.score.value = 0;
        }
    }
}

[System.Serializable]
public class ScoreSetup
{
    public SO_Score score;
    public PlayerType playerType;
}
