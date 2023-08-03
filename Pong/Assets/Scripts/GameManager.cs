using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;

    public ScoreController scoreController;

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
