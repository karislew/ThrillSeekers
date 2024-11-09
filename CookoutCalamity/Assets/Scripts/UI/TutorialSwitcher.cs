using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialSwitcher : MonoBehaviour
{
    public GameObject tutorialMenuUI;
    public GameObject tutorialFirstButton;
    public GameObject[] tutorialContainers;
    int index;

    private void Start()
    {
        // selecting the first tutorial button only works if this code is called in the start. Update selects it but navigation gets stuck.
        if (tutorialMenuUI.activeSelf)
        {
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected game object
            EventSystem.current.SetSelectedGameObject(tutorialFirstButton);
        }

        index = 0;
    }

    private void Update()
    {
        if (index >= tutorialContainers.Length)
        {
            index = tutorialContainers.Length;
        }

        if (index < 0)
        {
            index = 0;
        }

        if (index == 0)
        {
            tutorialContainers[0].SetActive(true);
        }
    }

    public void NextStep()
    {
        index += 1;
        for (int i = 0; i < tutorialContainers.Length; i++)
        {
            if (index != tutorialContainers.Length)
            {
                tutorialContainers[i].gameObject.SetActive(false);
                tutorialContainers[index].gameObject.SetActive(true);
            }
            else
            {
                index = 0;
                tutorialContainers[i].gameObject.SetActive(false);
                tutorialContainers[index].gameObject.SetActive(true);
            }

        }
        Debug.Log(index);
    }

    public void PreviousStep()
    {
        index -= 1;
        for (int i = 0; i < tutorialContainers.Length; i++)
        {
            if (index != -1)
            {
                tutorialContainers[i].gameObject.SetActive(false);
                tutorialContainers[index].gameObject.SetActive(true);
            }
            else
            {
                index = tutorialContainers.Length - 1;
                tutorialContainers[i].gameObject.SetActive(false);
                tutorialContainers[index].gameObject.SetActive(true);
            }

        }
        Debug.Log(index);
    }

    public void CloseStep()
    {
        tutorialMenuUI.SetActive(false);
    }
}
