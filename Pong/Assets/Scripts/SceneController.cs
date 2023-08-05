using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int sceneIndex;
    public void OnChangeScene()
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
