using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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

    PlayerInputActions playerControls;
    private InputAction space;
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        space =playerControls.Player.SpaceKey;
        space.Enable();
    }
    private void OnDisable()
    {
        space.Disable();
    }



    void Start()
    {
        //poof.SetActive(false);
        currentProgress = minProgress;
        progressBar.maxValue = maxProgress;
        progressBar.value = currentProgress;
        progressBar.gameObject.SetActive(true);
    }

    void Update()
    {
        bool isSpaceHeld = space.ReadValue<float>() >0.1f;
        // if (inTrig && Input.GetKey(KeyCode.Space))
        currentProgress = progressBar.value;
        if (inTrig && isSpaceHeld)
        {
            //poof.SetActive(true);
            if (regenCoroutine == null)
            {
                regenCoroutine = StartCoroutine(IncreaseProgress());
            }
        }
        //else if (!inTrig || !Input.GetKey(KeyCode.Space))
        else if (!inTrig || !isSpaceHeld)
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
