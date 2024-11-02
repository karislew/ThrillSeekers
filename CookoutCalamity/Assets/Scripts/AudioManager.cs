using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambientSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clip-----")]
    public AudioClip LevelAmbience;
    public AudioClip levelMusic;
    public AudioClip mainMenuMusic;
    public AudioClip winMenuMusic;
    public AudioClip loseMenuMusic;
    public AudioClip grillAmbience;
    public AudioClip buttonClick;
    public AudioClip momSpawnSFX;
    public AudioClip dadSpawnSFX;
    public AudioClip auntSpawnSFX;
    public AudioClip uncleSpawnSFX;
    public AudioClip familyEatingSFX;
    public AudioClip tableTakeSFX;
    public AudioClip tablePlaceGlassSFX;
    public AudioClip tablePlaceForkSFX;
    public AudioClip tablePlacePlateSFX;
    public AudioClip timerStartSFX;
    public AudioClip timerStopSFX;
    public AudioClip timerCountdownSFX;
    public AudioClip argueTeenSFX;
    public AudioClip argueTwinSFX;
    public AudioClip readyTeenSFX;
    public AudioClip readyTwinSFX;
    public AudioClip siblingPickUpSFX;
    public AudioClip siblingDropSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
