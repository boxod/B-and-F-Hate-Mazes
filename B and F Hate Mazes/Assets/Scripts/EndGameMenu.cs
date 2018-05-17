using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour {

    public void StartNewGame()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
