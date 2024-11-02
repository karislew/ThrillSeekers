using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject mainFirstButton;
    // Start is called before the first frame update
    void Start()
    {
        // selecting the first tutorial button only works if this code is called in the start. Update selects it but navigation gets stuck.
        if (mainMenuUI.activeSelf)
        {
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected game object
            EventSystem.current.SetSelectedGameObject(mainFirstButton);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
