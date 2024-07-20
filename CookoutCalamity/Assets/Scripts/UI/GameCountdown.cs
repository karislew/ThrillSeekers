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
    public GameObject player;
    private PTableInteract currentProgress_script;
    public float delay = 0.5f;
    private float timer;

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
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0 && currentProgress_script.currentProgress < 90)
        {
            remainingTime = 0;
            SceneManager.LoadScene("LoseMenu");
            Debug.Log("You Lose!");
        }
        else if (remainingTime <= 0 && currentProgress_script.currentProgress > 90)
        {
            remainingTime = 0;
            SceneManager.LoadScene("WinMenu");
            Debug.Log("You Win!");
        }

        if (remainingTime > 0 && currentProgress_script.currentProgress > 90)
        {
            //remainingTime = 0;
            SceneManager.LoadScene("WinMenu");
            Debug.Log("You Win!");
        }
    }
}
