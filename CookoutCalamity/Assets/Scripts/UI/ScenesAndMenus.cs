using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

        void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game. . .");
        Application.Quit();
    }


    public void LoadMainMenu()
    {
        Debug.Log("Loading main menu. . .");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //SceneManager.LoadScene("Karis");
    }

    public void LoadGameScene()
    {
        Debug.Log("Loading game scene. . .");
        SceneManager.LoadScene("2DCookout");
        Time.timeScale = 1f;
    }

    public void LoadWinMenu()
    {
        Debug.Log("Loading game scene. . .");
        SceneManager.LoadScene("WinMenu");
    }

    public void LoadLoseMenu()
    {
        Debug.Log("Loading game scene. . .");
        SceneManager.LoadScene("LoseMenu");
    }



}
