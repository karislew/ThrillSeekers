using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OrigSceneMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    private PlayerMovement playerMove_script;
    private PTableInteract playerTable_script;
    private SiblingPickUp playerSibling_script;
    public GameObject player;
    public AudioSource audioSource;
    public GameObject startMenuUI;

    // The first button selected when you pause the game
    public GameObject pauseFirstButton;
    // The first option that is selected when closing the options or tutorial menu
    public GameObject optionsCloseButton;

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

    //Inputs for Keyboard and Controller
    PlayerInputActions playerControls;
    private InputAction escape;
    private InputAction restartGame;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        escape = playerControls.UI.EscapeKey;
        escape.Enable();

        restartGame = playerControls.Player.DebugRestart;
        restartGame.Enable();
    }
    private void OnDisable()
    {
        escape.Disable();
        restartGame.Disable();
    }

    private void Start()
    {
        playerMove_script = player.GetComponent<PlayerMovement>();
        playerTable_script = player.GetComponent<PTableInteract>();
        playerSibling_script = player.GetComponent<SiblingPickUp>();
    }

    private void Update()
    {
        bool isESCPressed = escape.triggered;
        if (isESCPressed)
        {
            if (GameIsPaused)
            {
                Resume();
                audioSource.Play();

            }
            else
            {
                Pause();
                playerMove_script.enabled = false;
                playerTable_script.enabled = false;
                playerSibling_script.enabled = false;
            }
        }

        if (restartGame.triggered)
        {
            //LoadMainMenu();
        }

    }

    void Pause()
    {
        Debug.Log("Pausing game. . .");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        startMenuUI.SetActive(false);
    }

    public void Resume()
    {
        Debug.Log("Resuming game. . .");
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerMove_script.enabled = true;
        playerTable_script.enabled = true;
        playerSibling_script.enabled = true;
        startMenuUI.SetActive(true);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game. . .");
        Application.Quit();
    }
}
