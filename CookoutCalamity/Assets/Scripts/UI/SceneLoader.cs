using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Debug.Log("Loading main menu. . .");
        LevelManager.Instance.LoadScene("MainMenu", "CircleWipe");
        Time.timeScale = 1f;
    }

    public void LoadGameScene()
    {
        Debug.Log("Loading game scene. . .");
        LevelManager.Instance.LoadScene("2dCookout (3 Path)", "CircleWipe");
        Time.timeScale = 1f;
        NewPauseMenu.GameIsPaused = false;
    }

    public void LoadWinMenu()
    {
        Debug.Log("Loading win scene. . .");
        LevelManager.Instance.LoadScene("WinMenu", "CircleWipe");
    }

    public void LoadLoseMenu()
    {
        Debug.Log("Loading lose scene. . .");
        LevelManager.Instance.LoadScene("LoseMenu", "CircleWipe");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game. . .");
        Application.Quit();
    }
}
