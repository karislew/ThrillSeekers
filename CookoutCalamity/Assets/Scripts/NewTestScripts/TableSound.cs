using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableSound : MonoBehaviour
{
    public AudioClip[] tableSounds;
    private AudioSource audioSource;
    public Slider progressBar; 
    // Start is called before the first frame update
    float[] thresholds = {0,45,65};
    private int currentSoundState = -1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateSoundState();
        audioSource.loop=true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSoundState();
    }
    void UpdateSoundState()
    {
        for(int i = thresholds.Length-1; i >= 0;i--)
        {
            if(progressBar.value>=thresholds[i])
            {
                if(currentSoundState!=i)
                {
                    currentSoundState = i;
                    SetSoundState(i);
                }
                break;
            }
        }
    }
    void SetSoundState(int activeSound)
    {
        if(activeSound<0 || activeSound>=tableSounds.Length) return;
        Debug.Log("SOUND SOUND "+activeSound + " " + tableSounds[activeSound]);

        audioSource.clip  = tableSounds[activeSound];
        if(!audioSource.isPlaying || audioSource.clip!=tableSounds[activeSound])
        {
            audioSource.Play();
        }
        
    }
}
