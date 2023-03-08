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
        SceneManager.UnloadSceneAsync("Victory");
        SceneManager.LoadSceneAsync("Wipeout");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Wipeout");
    }

    public void MenuScreen()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
