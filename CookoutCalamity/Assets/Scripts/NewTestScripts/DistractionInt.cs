using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistractionInt : MonoBehaviour
{
    private Transform target;
    public Transform siblingSpot;
    public Transform siblingPosition;
    private GameObject nearestEnemy = null;
    //public PositionsManager positionsManager;
    public GameObject speechUI;
    public AudioClip arguing;

    [SerializeField] private Image uiFill;
    public GameObject uiTimer;
    public int Duration;
    private int remainingDuration;
 




    public float range = 5f;
    public string enemyTag = "Enemy";

    private Interactions interactionScript;

    void Awake()
    {
        uiTimer.SetActive(false);
    }

    void Start()
    {
        speechUI.SetActive(false);
        interactionScript = GetComponent<Interactions>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(enemyTag))
        {
            if (target == null)
            {
                nearestEnemy = col.gameObject;
                target = nearestEnemy.transform;
                uiTimer.SetActive(true);
                //speechUI.SetActive(true);
                Being(Duration);

                nearestEnemy.GetComponent<TestMovement>().enabled = false;
                interactionScript.SetPickUpState(false);

                if (target.transform.position != siblingSpot.transform.position)
                {
                    nearestEnemy.GetComponent<Rigidbody2D>().simulated = false;
                    target.transform.position = siblingSpot.transform.position;
                }

                //StartCoroutine(Wait(nearestEnemy, siblingPosition));

                AudioSource.PlayClipAtPoint(arguing, transform.position, 2f);
            }
        }
    }

    private void Being(int seconds)
    {
        remainingDuration=seconds;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    
    {
        while(remainingDuration >= 0 )
        {
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(OnEnd());
    }
    IEnumerator OnEnd()
    {
       uiFill.fillAmount = 1;
       yield return new WaitForSeconds(.01f);
       Destroy(nearestEnemy);
       speechUI.SetActive(false);
       yield return new WaitForSeconds(.01f);
       target = null;
       transform.position = siblingPosition.position;
       uiTimer.SetActive(false);
       interactionScript.SetPickUpState(true);

    }

/*
    IEnumerator Wait(GameObject nearestEnemy, Transform siblingPosition)
    {
        yield return new WaitForSeconds(5f);
        Destroy(nearestEnemy);
        speechUI.SetActive(false);
        target = null;
        transform.position = siblingPosition.position;
        interactionScript.SetPickUpState(true);
    }
*/

}
