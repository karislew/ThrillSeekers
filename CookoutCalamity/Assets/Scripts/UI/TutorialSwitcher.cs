using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialSwitcher : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public GameObject startMenuUI;

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

    // Grabbing the event system to detect first selected object and detect what input device is being used.
    public EventSystem eventSystemUI;
    public void PointerExit()
    {
        eventSystemUI.SetSelectedGameObject(null);

        if (Input.GetAxisRaw("Vertical") != 0 && (eventSystemUI.currentSelectedGameObject == null || !eventSystemUI.currentSelectedGameObject.activeSelf))
        {
            eventSystemUI.SetSelectedGameObject(eventSystemUI.firstSelectedGameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
    

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
