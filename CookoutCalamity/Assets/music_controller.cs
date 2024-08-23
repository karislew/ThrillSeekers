using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_controller : MonoBehaviour
{
    // Start is called before the first frame update
    private PauseMenu pause_script;
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
        if (PauseMenu.GameIsPaused == true)
        {
            theme.Pause();
        }

        else
        {
            theme.UnPause();
        }
    }
}
