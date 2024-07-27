using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Start()
    {
        
    }

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
        Debug.Log("Pausing game. . .");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Resuming game. . .");
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
        LevelManager.Instance.LoadScene("MainMenu", "CircleWipe");
        //SceneManager.LoadScene("Karis");
        Time.timeScale = 1f;
    }

    public void LoadGameScene()
    {
        Debug.Log("Loading game scene. . .");
        LevelManager.Instance.LoadScene("2DCookout", "CircleWipe");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadWinMenu()
    {
        Debug.Log("Loading win scene. . .");
        LevelManager.Instance.LoadScene("WinMenu", "CrossFade");
    }

    public void LoadLoseMenu()
    {
        Debug.Log("Loading lose scene. . .");
        LevelManager.Instance.LoadScene("LoseMenu", "CrossFade");
    }



}
