using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableProgress : MonoBehaviour
{
    public GameObject[] tableStates; // Array to hold the different table states
    public Slider progressBar;       // Reference to the progress bar UI element

    void Start()
    {
        SetTableState(0); // Start with the first state active
    }

    void Update()
    {
        // Define the progress thresholds for each state
        float[] thresholds = { 0, 20, 35, 55, 75, 90};

        // Determine which state should be active based on the progress bar value
        for (int i = thresholds.Length - 1; i >= 0; i--)
        {
            if (progressBar.value >= thresholds[i])
            {
                SetTableState(i);
                break;
            }
        }
    }

    void SetTableState(int activeState)
    {
        for (int i = 0; i < tableStates.Length; i++)
        {
            tableStates[i].SetActive(i == activeState);
        }
    }
}
