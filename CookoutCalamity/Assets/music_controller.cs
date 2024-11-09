using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_controller : MonoBehaviour
{
    private AudioSource theme;

    private void Awake()
    {
        theme = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NewPauseMenu.GameIsPaused == true)
        {
            theme.Pause();
        }

        else
        {
            theme.UnPause();
        }
    }
}
