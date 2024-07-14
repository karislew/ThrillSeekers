using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyTableInt : MonoBehaviour
{
    public Slider progressBar;
    //public float decrementRate = 5.0f; // Adjust this rate as needed
    public float decProgress;


    /*
    private void Update()
    {
        if (progressBar != null && progressBar.value > 0)
        {
            DecreaseProgress(1);
        }
    }

    */

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Table"))
        {
            DecreaseProgress(decProgress);
            
            Debug.Log("Enemy entered table trigger.");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Table"))
        {
            Debug.Log("Enemy exited table trigger.");
        }
    }

    void DecreaseProgress(float progress)
    {
       
        
        progressBar.value -=progress;
       


        //progressBar.value -= progress;
       
    }
}
