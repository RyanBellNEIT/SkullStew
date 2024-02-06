using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartCountDown()
    {
        SceneManager.LoadScene("Game Scene Countdown");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game Scene"); 
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
