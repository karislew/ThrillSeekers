/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PTableInteract : MonoBehaviour
{
    //make progress
    public int minProgress=0;
    public int maxProgress=100;
    public int currentProgress;
    //public ProgressBar progressBar;
    public Slider progressBar;
    private WaitForSeconds regenTick = new WaitForSeconds(.1f);
    private bool inTrig=false;
    private Coroutine regen;
    
    /*
    public static PTableInteract instance;
   
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

  
    // Start is called before the first frame update
    void Start()
    {
        //when we start game the current progress will be set to 0
        currentProgress=minProgress;
        progressBar.maxValue=maxProgress;
        
    }

    // Update is called once per frame

    
    void Update()
    {
        //when we press e increase the bar 
        if (inTrig)
        {
            if(Input.GetKey(KeyCode.Space)){
                if(regen==null)
                {
                    regen = StartCoroutine(RegenStamina());
                }


            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                if(regen!=null)
                {
                    StopCoroutine(regen);   
                    regen=null;
                }
            }

            /*
            if(Input.GetKeyDown(KeyCode.Space))
            {
                IncreaseProgress(1);
                Debug.Log("Current progress" + currentProgress);
            }
           
        }
        
    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Table"))
        {
            Debug.Log("COLLIDEEE");
            inTrig=true;

           
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Table"))
        {
            Debug.Log("NOT COLLIDE");
            inTrig=false;
            if(regen!=null)
            {
                StopCoroutine(regen);
                regen=null;
            }

           
        }
    }
    /*
    void IncreaseProgress(int progress)
    {
        //add the progress to current progress
        currentProgress+=progress;
        progressBar.value=currentProgress;
    }
   
    private IEnumerator RegenStamina()
    {
        //yield return new WaitForSeconds(1f);
        while(currentProgress<maxProgress)
        {
            currentProgress += maxProgress/50;
            
            progressBar.value=currentProgress;
    
            yield return regenTick;
        }
        regen=null;

    }
}
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PTableInteract : MonoBehaviour
{
    public int minProgress = 0;
    public int maxProgress;
    public float currentProgress;
    public Slider progressBar;
    private bool inTrig = false;
    private Coroutine regenCoroutine;
    public GameObject poof;
    private WaitForSeconds progressTick = new WaitForSeconds(0.2f); // Time interval between progress increments

    void Start()
    {
        poof.SetActive(false);
        currentProgress = minProgress;
        progressBar.maxValue = maxProgress;
        progressBar.value = currentProgress;
        progressBar.gameObject.SetActive(true);
    }

    void Update()
    {
        currentProgress = progressBar.value;
        if (inTrig && Input.GetKey(KeyCode.Space))
        {
            //poof.SetActive(true);
            if (regenCoroutine == null)
            {
                regenCoroutine = StartCoroutine(IncreaseProgress());
            }
        }
        else if (!inTrig || !Input.GetKey(KeyCode.Space))
        {
            //poof.SetActive(false);
            if (regenCoroutine != null)
            {
                StopCoroutine(regenCoroutine);
                regenCoroutine = null;
            }
            
        }
        //progressBar.value=currentProgress;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Table"))
        {
            //Debug.Log("COLLIDEEE");
            inTrig = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Table"))
        {
            //Debug.Log("NOT COLLIDE");
            inTrig = false;
            //progressBar.value=currentProgress;
        }
    }

    private IEnumerator IncreaseProgress()
    {
        while (currentProgress < maxProgress)
        {
            
            currentProgress+=.4f;
            progressBar.value = currentProgress;
           // Debug.Log("Current Progress: " + currentProgress);
            yield return progressTick;
        }
    }
}
