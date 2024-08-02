using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCountdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public Slider progressBar;
    public GameObject player;
    private PTableInteract currentProgress_script;
    public float delay = 0.5f;
    private float timer;
    public bool hasPlayed = false;
    public AudioClip countdown;

    void Start()
    {
        currentProgress_script = player.GetComponent<PTableInteract>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > delay)
        {
            CountDownClock();
        }

    }
    public void CountDownClock()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}: {1:00}", minutes, seconds);

        if (remainingTime > 0)
        {
            if (remainingTime <= 21 && hasPlayed == false)
            {
                AudioSource scriptedCountdown;
                Debug.Log("Start countdown");
                scriptedCountdown = GetComponent<AudioSource>();
                scriptedCountdown.Play();
                hasPlayed = true;
            }
            remainingTime -= Time.deltaTime;
        }
        //remainingTime <= 0 && currentProgress_script.currentProgress < 90

        else if (remainingTime <= 0 && progressBar.value < 90)
        {
            Debug.Log("IN THIS " + remainingTime);
            remainingTime = 0;
            SceneManager.LoadScene("LoseMenu");
            Debug.Log("You Lose!");
        }
        //remainingTime <= 0 && currentProgress_script.currentProgress > 90
        else if (remainingTime <= 0 && progressBar.value > 98)
        {
            remainingTime = 0;
            SceneManager.LoadScene("WinMenu");
            Debug.Log("You Win!");
        }
        //remainingTime > 0 && currentProgress_script.currentProgress 
        if (remainingTime > 0 && progressBar.value == 100)
        {
            //remainingTime = 0;
            SceneManager.LoadScene("WinMenu");
            Debug.Log("You Win!");
        }
    }
}