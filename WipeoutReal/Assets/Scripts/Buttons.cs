using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetryGame()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(0);
    }
}
