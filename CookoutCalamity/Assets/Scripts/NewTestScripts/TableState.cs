using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableProgress : MonoBehaviour
{
    public GameObject state1;
    public GameObject state2;
    public GameObject state3;
    public GameObject state4;
    public GameObject state5;
    public GameObject state6;
    public Slider progressBar;
    // Start is called before the first frame update
    void Start()
    {
        state1.SetActive(true);
        state2.SetActive(false);
        state3.SetActive(false);
        state4.SetActive(false);
        state5.SetActive(false);
        state6.SetActive(false);


    }
    void Update()
    {
        if (progressBar.value == 15)
        {
            state1.SetActive(false);
            state2.SetActive(true);
            state3.SetActive(false);
            state4.SetActive(false);
            state5.SetActive(false);
            state6.SetActive(false);

   
        }
        else if (progressBar.value == 30)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(true);
            state4.SetActive(false);
            state5.SetActive(false);
            state6.SetActive(false);

        }
        else if (progressBar.value == 45)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            state4.SetActive(true);
            state5.SetActive(false);
            state6.SetActive(false);

        }
        else if (progressBar.value == 60)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            state4.SetActive(false);
            state5.SetActive(true);
            state6.SetActive(false);

        }
        else if (progressBar.value == 75)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            state4.SetActive(false);
            state5.SetActive(true);
            state6.SetActive(false);

        }
        else if (progressBar.value == 90)
        {
            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            state4.SetActive(false);
            state5.SetActive(false);
            state6.SetActive(true);

        }
        
    }
}
