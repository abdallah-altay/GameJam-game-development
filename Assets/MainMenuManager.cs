using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject menu;
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Info()
    {
        menu.SetActive(!menu.activeSelf);
        tutorial.SetActive(!tutorial.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
