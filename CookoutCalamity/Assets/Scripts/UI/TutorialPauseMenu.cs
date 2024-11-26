using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialPauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool pauseOnStart = false;
    public GameObject pauseMenuUI;
    //public GameObject optionsMenuUI;
    public Button nextButton;
    public Button prevButton;
    //public TutorialSwitcher tutorialSwiter_Script;
    private PlayerMovement playerMove_script;
    private PTableInteract playerTable_script;
    private SiblingPickUp playerSibling_script;
    public GameObject player;
    public SceneLoader sceneLoader_script;


    // The first button selected when you pause the game
    public GameObject pauseFirstButton;
    // The first option that is selected when closing the options or tutorial menu
    //public GameObject optionsCloseButton;

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
        
        if (pauseOnStart == true )
        {
            Pause();
        }

    }

    private void Update()
    {
        bool isESCPressed = escape.triggered;
        if (isESCPressed)
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

        if (restartGame.triggered)
        {
            Debug.Log("Restarting whole game.");
            sceneLoader_script.LoadMainMenu();
        }
    }

    void Pause()
    {
        Debug.Log("Pausing game. . .");
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        nextButton.interactable = true;
        prevButton.interactable = true;
        playerMove_script.enabled = false;
        playerTable_script.enabled = false;
        playerSibling_script.enabled = false;
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

    }

    public void Resume()
    {
        Debug.Log("Resuming game. . .");
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        //optionsMenuUI.SetActive(false);
        //tutorialSwiter_Script.tutorialMenuUI.SetActive(false);
        playerMove_script.enabled = true;
        playerTable_script.enabled = true;
        playerSibling_script.enabled = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected game object
        //EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        //pauseOnStart = true;
    }
}
