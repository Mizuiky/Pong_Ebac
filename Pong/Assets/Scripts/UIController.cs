using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scorePlayer1;
    public TextMeshProUGUI scorePlayer2;

    public TextMeshProUGUI winnerText;
    public GameObject winnerScreen;

    public void Start()
    {
        Init();
    }

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

    private void Init()
    {
        winnerScreen.SetActive(false);

        scorePlayer1.text = "0";
        scorePlayer2.text = "0";
    }

    public void SetWinner(string winner, bool active)
    {
        winnerText.text = winner;

        winnerScreen.SetActive(active);

        scorePlayer1.text =  "0";
        scorePlayer2.text = "0";
    }
}
