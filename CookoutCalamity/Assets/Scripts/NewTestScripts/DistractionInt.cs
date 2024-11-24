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
    public float Duration;
    private float remainingDuration;
 




    public float range = 2f;
    public string enemyTag = "Enemy";

    private Interactions interactionScript;
    public float glideDuration = 5f;
    private bool isGliding = false;

    void Awake()
    {
        uiTimer.SetActive(false);
    }

    void Start()
    {
        speechUI.SetActive(false);
        interactionScript = GetComponent<Interactions>();
    }
    void Update()
    {
        if(isGliding && target != null)
        {
            target.position = Vector3.Lerp(target.transform.position,transform.position, glideDuration * Time.deltaTime);
            
            
            //Debug.Log(Vector3.Distance(target.position, transform.position));
            if (Vector3.Distance(target.position, transform.position) < 10f)
            {
                
                //target.position = siblingSpot.position;
                
                //nearestEnemy.GetComponent<Animator>().SetFloat("Horizontal",1);
                //nearestEnemy.GetComponent<Animator>().SetFloat("Vertical",0);
                uiTimer.SetActive(true);
                Being(Duration);
                    
               
                
                
                
                
                isGliding = false; // Stop gliding
                
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(enemyTag))
        {
            if (target == null)
            {
                nearestEnemy = col.gameObject;
                target = nearestEnemy.transform;
                
                //speechUI.SetActive(true);
                

                nearestEnemy.GetComponent<TestMovement>().enabled = false;
                
                
                interactionScript.SetPickUpState(false);

                if (target.transform.position != siblingSpot.transform.position)
                {
                    nearestEnemy.GetComponent<Rigidbody2D>().simulated = false;
                    //target.transform.position = siblingSpot.transform.position;
                    isGliding= true;
                    nearestEnemy.GetComponent<Animator>().SetFloat("Speed",0);
                    //Being(Duration);
                    

                    

                    //StartCoroutine(GlideToPosition(target, siblingSpot.position, glideDuration));

                    
                    

                    
                }
               


             
                //StartCoroutine(Wait(nearestEnemy, siblingPosition));

                AudioSource.PlayClipAtPoint(arguing, transform.position, 2f);
            }
        }
    }

    private void Being(float seconds)
    {
        remainingDuration=seconds;
        
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    
    {
        //yield return new WaitForSeconds(1f);
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

    private IEnumerator GlideToPosition(Transform target, Vector3 endPosition, float duration)
    {
        Vector3 startPosition = target.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            target.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the target snaps exactly to the final position at the end
        target.position = endPosition;
    }

    void OnDrawGizmos()
   {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position,range);


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
