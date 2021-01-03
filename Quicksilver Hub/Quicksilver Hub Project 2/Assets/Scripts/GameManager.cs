using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

 

    public void startGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Main Game");
    }


    public void backToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
