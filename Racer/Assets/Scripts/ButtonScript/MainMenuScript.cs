using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1.1"); // play game
    }

    public void EndGame()
    {
        Application.Quit();  // close game
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); // open mainmenu
    }
}
