using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Player1,
    Player2
}

public class ScoreManager : MonoBehaviour
{
    public List<ScoreSetup> scores;

    public void SetPoints(PlayerType type)
    {
        var setup = scores.Find(x => x.playerType == type);

        setup.score.value += 1;

        GameManager.Instance.UiController.SetScoreText(setup.playerType, setup.score.value);
    }
}

public class ScoreSetup
{
    public Score score;
    public PlayerType playerType;
}
