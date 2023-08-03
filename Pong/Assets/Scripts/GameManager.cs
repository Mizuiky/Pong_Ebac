using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIController uiController;

    private ScoreManager scoreManager;

    public UIController UiController
    {
        get { return uiController;  }
    }

    public ScoreManager ScoreManager
    {
        get { return scoreManager;  }
    }

    public static GameManager Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = GetComponent<GameManager>();
        }

        Destroy(Instance.gameObject);
    }



}
