using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TableProgress : MonoBehaviour
{
    public GameObject poof;
    public GameObject[] tableStates; // Array to hold the different table states
    public Slider progressBar;       // Reference to the progress bar UI element
    private bool tableState;
    private bool inTrig = false;
    private AudioSource table_sfx;
    private SiblingPickUp siblingPickup;
    public GameObject player; 
   

    //Inputs for Keyboard and Controller
    PlayerInputActions playerControls;
    private InputAction space;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
       
        
    }
    private void OnEnable()
    {
        space = playerControls.Player.SpaceKey;
        space.Enable();
    }
    private void OnDisable()
    {
        space.Disable();
    }


    void Start()
    {
        siblingPickup = player.GetComponent<SiblingPickUp>();
        tableState=false;
        poof.SetActive(false);
        SetTableState(0); // Start with the first state active
    }

    void Update()
    {
        bool isSpaceHeld = space.ReadValue<float>() > 0.1f;

        // Define the progress thresholds for each state
        float[] thresholds = { 0, 20, 35, 55, 75, 90};

        // Determine which state should be active based on the progress bar value
        for (int i = thresholds.Length - 1; i >= 0; i--)
        {
            tableState=false;

            if (progressBar.value >= thresholds[i])
            {

    
                SetTableState(i);
                break;
            }
        }
        if(inTrig && isSpaceHeld && tableState==false && siblingPickup.tableInteract == false)
        {
            poof.SetActive(true);
        }

        else if (!inTrig || !isSpaceHeld || tableState==true || siblingPickup.tableInteract == true)
        {
            poof.SetActive(false);
        }
        
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.CompareTag("Player"))
        {
            inTrig=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
      
            inTrig = false;
     
        }
    }
    void SetTableState(int activeState)
    {
       
        for (int i = 0; i < tableStates.Length; i++)
        {

            //tableState=true;
            tableStates[i].SetActive(i == activeState);
        }
    }
}
