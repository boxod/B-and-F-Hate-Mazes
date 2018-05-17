using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    //check if game is Paused
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject areYouSure;
    public GameObject settingsMenu;


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AreYouSureClose();
        closenSettingsMenu();
    }


    public void openSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void closenSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void goToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Main Menu Scene");

    }


    public void AreYouSureOpen()
    {
        areYouSure.SetActive(true);
    }

    public void AreYouSureClose()
    {
        areYouSure.SetActive(false);
    }

    public void hidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
    }

    public void showPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void PauseOrUnpause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}
}
