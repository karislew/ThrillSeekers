using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    // The first button selected when you pause the game
    public GameObject pauseFirstButton;
    // The first option that is selected when closing the options or tutorial menu
    public GameObject optionsCloseButton;

    // Tutorial Navigation Setup
    public GameObject tutorialMenuUI1;
    public GameObject tutorialMenuUI2;
    public GameObject tutorialMenuUI3;
    public GameObject tutorialMenuUI4;
    public GameObject tutorialMenuUI5;
    public GameObject tutorialMenuUI6;
    public GameObject tutorialMenuUI7;
    public GameObject tutorialMenuUI8;

        // The Next button will be selected first upon menu activation
    public GameObject tutorialFirstButton1;
    public GameObject tutorialFirstButton2;
    public GameObject tutorialFirstButton3;
    public GameObject tutorialFirstButton4;
    public GameObject tutorialFirstButton5;
    public GameObject tutorialFirstButton6;
    public GameObject tutorialFirstButton7;
    public GameObject tutorialFirstButton8;
    // Tutorial Navigation Setup

    //Inputs for Keyboard and Controller
    PlayerInputActions playerControls;
    private InputAction escape;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        escape = playerControls.UI.EscapeKey;
        escape.Enable();
    }
    private void OnDisable()
    {
        escape.Disable();
    }

    // Selecting first buttion in the event system
    //public Button primaryButton;
    private void Start()
    {
        //primaryButton.Select();
    }

    private void Update()
    {
        bool isESCPressed = escape.triggered;
        if (isESCPressed)
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

        //clear selected object
        //EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        //EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void Resume()
    {
        Debug.Log("Resuming game. . .");
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        CloseTutorialMenus();
        Time.timeScale = 1f;
        GameIsPaused = false;
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject (optionsCloseButton);
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
        LevelManager.Instance.LoadScene("2dCookout", "CircleWipe");
        Time.timeScale = 1f;
        GameIsPaused = false;
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

    public void LoadTutorialScene()
    {
        Debug.Log("Loading tutorial scene. . .");
        LevelManager.Instance.LoadScene("TutorialScene", "CircleWipe");
        Time.timeScale = 1f;
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(tutorialFirstButton1);
    }

    public void LoadTutorialMenus()
    {
        Debug.Log("Opening Tutorial. . .");
        tutorialMenuUI1.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(tutorialFirstButton1);
    }

    public void CloseTutorialMenus()
    {
        Debug.Log("Closing Tutorial. . .");
        tutorialMenuUI1.SetActive(false);
        tutorialMenuUI2.SetActive(false);
        tutorialMenuUI3.SetActive(false);
        tutorialMenuUI4.SetActive(false);
        tutorialMenuUI5.SetActive(false);
        tutorialMenuUI6.SetActive(false);
        tutorialMenuUI7.SetActive(false);
        tutorialMenuUI8.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }


}
