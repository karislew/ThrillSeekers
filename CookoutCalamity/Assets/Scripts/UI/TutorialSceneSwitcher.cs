using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneSwitcher : MonoBehaviour
{
    public GameObject tutorialMenuUI;
    public GameObject tutorialFirstButton;
    public GameObject[] tutorialContainers;
    public string[] sceneContainers;
    public int currentSceneCount;
    private Scene currentScene;
    private string sceneName;
    
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

        //index = 0;
        //index = sceneContainers[index].GetHashCode();
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current Scene " + currentScene.name);
        
        
        
        if (sceneContainers[index] != sceneName)
        {
            //index = sceneContainers[index].GetHashCode();
        }
        for (int i=0; i<sceneContainers.Length;i+=1)
        {
          
            if(sceneContainers[i] == currentScene.name)
            {
                index = i;
                break;

            }
        }
        
    }


    private void Update()
    {
       
        if (index >= sceneContainers.Length)
        {
            index = sceneContainers.Length;
        }

        if (index < 0)
        {
            index = 0;
        }

        if (index == 0)
        {
            //SceneManager.LoadScene(sceneContainers[0]);
        }
    }

    public void NextStep()
    {
        index += 1;
        for (int i = 0; i < sceneContainers.Length; i++)
        {
            if (index != sceneContainers.Length)
            {
                SceneManager.LoadScene(sceneContainers[index]);
                
            
            }
            else
            {
                index = 0;
                SceneManager.LoadScene(sceneContainers[index]);
            }
        }
        Debug.Log(index);
    }

    public void PreviousStep()
    {
        index -= 1;
        for (int i = 0; i < sceneContainers.Length; i++)
        {
            if (index != -1)
            {
                SceneManager.LoadScene(sceneContainers[index]);
            }
            else
            {
                index = sceneContainers.Length - 1;
                SceneManager.LoadScene(sceneContainers[index]);
            }

        }
        Debug.Log(index);
    }

    public void CloseStep()
    {
        tutorialMenuUI.SetActive(false);
    }
}
