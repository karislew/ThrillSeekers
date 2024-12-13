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
   private NewPauseMenu pauseMenu_script;
   private EnemySpawn enemySpawner_script;
   //public DepleteProgress depleteProgress_script;
   private PTableInteract pTable_script;
   public GameObject gameManager,player, pause;
   public TMP_Text countdownDisplay;


   private PTableInteract currentProgress_script;
   public float delay = 0.5f;
   private float timer;
   public bool hasPlayed = false;
   public AudioClip countdown;
   private bool gameEnded = false;  // Flag to prevent repeated scene loads
   private Animator animator;
   public int countdownTime;
   private bool countStart = false;
  


   void Start()
   {
       Countdown.onCountdownComplete+=StartGame;


       animator = player.GetComponent<Animator>();
       playerMove_script = player.GetComponent<PlayerMovement>();
       playerTable_script = player.GetComponent<PTableInteract>();
       playerSibling_script = player.GetComponent<SiblingPickUp>();
       enemySpawner_script = gameManager.GetComponent<EnemySpawn>();
       pauseMenu_script = pause.GetComponent<NewPauseMenu>();
       pTable_script = player.GetComponent<PTableInteract>();
      
      
      


       playerMove_script.enabled =false;
       playerTable_script.enabled =false;
       playerSibling_script.enabled =false;
       enemySpawner_script.enabled =false;
       pauseMenu_script.enabled =false;




       int minutes = Mathf.FloorToInt(remainingTime / 60);
       int seconds = Mathf.FloorToInt(remainingTime % 60);
       timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);




   }
   private void StartGame()
   {
       playerMove_script.enabled =true;
       playerTable_script.enabled =true;
       playerSibling_script.enabled =true;
       enemySpawner_script.enabled =true;
       pauseMenu_script.enabled =true;




   }
   void OnDestroy()
   {
       Countdown.onCountdownComplete-=StartGame;
   }


   void Update()
   {
       if(playerMove_script.enabled){
           timer += Time.deltaTime;
           if (timer > delay && !gameEnded)
           {
               CountDownClock();
            }
        
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
               animator.SetFloat("Speed", 0);
               animator.SetBool("tableSetUp", false);
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
       if(seconds == 5 && minutes == 0 && countStart == false)
       {
        
        countdownDisplay.gameObject.SetActive(true);
        countStart= true;
        StartCoroutine(CountdownEnd());
       }
   }


   private void EndGame()
   {
       // Check conditions once and handle win/lose
       if (!gameEnded)
       {
            // Prevent repeated calls


           // Lose condition
           if (progressBar.value < 98)
           {
              
               Debug.Log("You Lose!");
              
               StartCoroutine(Wait("LoseMenu"));
              
           }
           // Win condition if progress bar is above the threshold
           else if (progressBar.value >= 98)
           {
               Debug.Log("You Win!");
               StartCoroutine(Wait("WinMenu"));
              
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
   IEnumerator Wait(string screenName)
   {
       yield return new WaitForSeconds(.1f);
       SceneManager.LoadScene(screenName);
       gameEnded = true;
   }

   IEnumerator CountdownEnd()
   {
     while(countdownTime>0)
     {
        countdownDisplay.text= countdownTime.ToString();
        yield return new WaitForSeconds(1f);
        countdownTime-=1;

     }
     countdownDisplay.text= "STOP";
     pTable_script.enabled= false;
     EndGame();
      

     //countdownDisplay.gameObject.SetActive(false);
   }

}

