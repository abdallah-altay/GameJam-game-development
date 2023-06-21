using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Info()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
