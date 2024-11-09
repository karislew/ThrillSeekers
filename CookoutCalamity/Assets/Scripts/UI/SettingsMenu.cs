using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsMenuUI;
    public GameObject settingsFirstButton;

    public AudioMixer audioMixer;
    public Toggle fullScreenToggle;
    bool isFullScreen;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        // selecting the first tutorial button only works if this code is called in the start. Update selects it but navigation gets stuck.
        if (settingsMenuUI.activeSelf)
        {
            //clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected game object
            EventSystem.current.SetSelectedGameObject(settingsFirstButton);
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRateRatio;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullScreenToggle.isOn = isFullScreen;
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("MusicVolume", musicVolume);
        Debug.Log(musicVolume);
    }

    public void SetSFXVolume(float SFXVolume)
    {
        audioMixer.SetFloat("SFXVolume", SFXVolume);
        Debug.Log(SFXVolume);
    }

    public void LoadSFXVolume()
    {
        //audioMixer.value = PlayerPrefs.GetFloat("SFXVolume");
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
