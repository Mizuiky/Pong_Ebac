using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;

    public void SetScoreText(PlayerType player, int value)
    {
        switch(player)
        {
            case PlayerType.Player1:
                scorePlayer1.text = value.ToString();
                break;
            case PlayerType.Player2:
                scorePlayer2.text = value.ToString();
                break;
        }
    }
}
