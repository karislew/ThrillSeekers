using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxProgress(int progress)
    {
        slider.maxValue = progress;
        //makes sure slider starts at the maximum health 
        slider.value=progress;

    
    }

    public void SetProgress(int progress)
    {

        slider.value = progress;

    }


    // Start is called before the first frame update
    
}
