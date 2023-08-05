using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button [] menuButton;
    public Color textColor;
    public float duration;

    public GameObject ruleText;

    private int index;
    private TextMeshProUGUI[] menuText;
    private int upArrowIndex;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            index++;

            if(index >= menuText.Length)
                index = 0;

            if(index == 0 )
                menuText[menuText.Length - 1].color = Color.white;
            else
                menuText[index - 1].color = Color.white;

            menuText[index].color = textColor;                           
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;

            if (index == -1)
            {
                menuText[0].color = Color.white;
                index = menuText.Length - 1;
            }
            else
                menuText[index + 1].color = Color.white;      

            menuText[index].color = textColor;            
        }
        else if(Input.GetKeyDown(KeyCode.Backspace))
        {
            menuButton[index].onClick.Invoke();
        }
    }

    private void Init()
    {
        index = 0;
        textColor = Color.blue;
        ruleText.SetActive(false);
        menuText = new TextMeshProUGUI[menuButton.Length];

        for (int i = 0; i < menuButton.Length; i++)
        {
            var text = menuButton[i].GetComponentInChildren<TextMeshProUGUI>();

            if (text != null)
                menuText[i] = text;
        }

        for(int i = 0; i < menuText.Length; i++)
        {
            if(i == 0)
                menuText[i].color = textColor;

            else
                menuText[i].color = Color.white;
        }        
    }

    private void ChangeTitleColor()
    {
        var time = 0f

        if( time < duration)
        {

        }
    }
}
