using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableProgress : MonoBehaviour
{
    public GameObject poof;
    public GameObject[] tableStates; // Array to hold the different table states
    public Slider progressBar;       // Reference to the progress bar UI element
    private bool tableState;
    private bool inTrig = false;

    void Start()
    {
        tableState=false;
        poof.SetActive(false);
        SetTableState(0); // Start with the first state active
    }

    void Update()
    {
        
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
        if(inTrig && Input.GetKey(KeyCode.Space)&& tableState==false)
        {
            poof.SetActive(true);
        }

        else if (!inTrig || !Input.GetKeyDown(KeyCode.Space) || tableState==true)
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
