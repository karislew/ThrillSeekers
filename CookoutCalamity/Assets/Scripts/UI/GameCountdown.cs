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
    private PlayerMovement playerMove_script;
    private PTableInteract playerTable_script;
    private SiblingPickUp playerSibling_script;
    public GameObject player;
    private PTableInteract currentProgress_script;
    public float delay = 0.5f;
    private float timer;
    public bool hasPlayed = false;
    public AudioClip countdown;
     private bool gameEnded = false;  // Flag to prevent repeated scene loads

    void Start()
    {
        playerMove_script = player.GetComponent<PlayerMovement>();
        playerTable_script = player.GetComponent<PTableInteract>();
        playerSibling_script = player.GetComponent<SiblingPickUp>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay && !gameEnded)
        {
            CountDownClock();
        }
    }

    public void CountDownClock()
    {
        // Reduce the time if above zero
        if (remainingTime > 0)
        {
            if (remainingTime <= 21 && !hasPlayed)
            {
                Debug.Log("Start countdown");
                AudioSource scriptedCountdown = GetComponent<AudioSource>();
                scriptedCountdown.Play();
                hasPlayed = true;
            }
            remainingTime -= Time.deltaTime;

            // Clamp remaining time to zero to avoid negative values
            if (remainingTime < 0)
            {
                remainingTime = 0;
                playerMove_script.enabled = false;
                playerTable_script.enabled = false;
                playerSibling_script.enabled = false;
            }
        }

        // Handle win/lose conditions once the timer hits zero or the progress bar is full
        if (remainingTime == 0)
        {
            EndGame();
        }
        else if (progressBar.value == 100)
        {
            WinGame();
        }

        // Update timer text (ensure it never shows negative time)
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        // Check conditions once and handle win/lose
        if (!gameEnded)
        {
             // Prevent repeated calls

            // Lose condition
            if (progressBar.value < 90)
            {
                
                Debug.Log("You Lose!");
                SceneManager.LoadScene("LoseMenu");
                StartCoroutine(Wait());
                gameEnded = true;
            }
            // Win condition if progress bar is above the threshold
            else if (progressBar.value >= 98)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene("WinMenu");
                gameEnded = true;
            }
        }
    }

    private void WinGame()
    {
        // Trigger win when progress bar hits 100
        if (!gameEnded)
        {
            gameEnded = true;  // Prevent repeated calls
            Debug.Log("You Win!");
            SceneManager.LoadScene("WinMenu");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
    }
}