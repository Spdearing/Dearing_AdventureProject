using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the end of the game Win Scene, it is very basic
/// </summary>

public class GameWinManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
       Application.Quit();   
    }
}
