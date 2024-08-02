using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionInt : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public Transform siblingSpot;
    public Transform siblingPosition;
    private GameObject nearestEnemy=null;
    public PositionsManager positionsManager;
    public GameObject speechUI;
    public AudioClip arguing;

    public float range = 5f;
    public string enemyTag="Enemy";

    void Start()
    {
        speechUI.SetActive(false);
    }
    /*
     void Update()
    {
        if(target==null)
            return;
       
        //target.transform.position=siblingSpot.transform.position;
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == enemyTag)
        {
            //Debug.Log("TargetTT");
         
            if(target==null){
                nearestEnemy=col.gameObject;
                target=nearestEnemy.transform;
                speechUI.SetActive(true);
                nearestEnemy.GetComponent<TestMovement>().enabled=false;
                //to fix the glitching
                if(target.transform.position!=siblingSpot.transform.position)
                {
                    nearestEnemy.GetComponent<Rigidbody2D>().simulated=false;
                    target.transform.position=siblingSpot.transform.position;

                }
                StartCoroutine(Wait(nearestEnemy,siblingPosition));

                AudioSource.PlayClipAtPoint(arguing, transform.position, 0.5f);
            }
            

        }
        else
        {
            target=null;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
    
    IEnumerator Wait(GameObject nearestEnemy, Transform siblingPosition)
    {
        yield return new WaitForSeconds(5f);
        Destroy(nearestEnemy);
        speechUI.SetActive(false);
        yield return new WaitForSeconds(.1f);
        target=null;
        transform.position=siblingPosition.position;
        //Transform sibPos = positionsManager.GetPosition();
        //transform.position = sibPos.position;
    }
    


/*
    void EnablePickUp()
    {
    rangeSpriteRenderer = itemHolding.transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (rangeSpriteRenderer != null)
            {
                rangeSpriteRenderer.enabled = true;
            }

            AudioSource.PlayClipAtPoint(audiopickup, transform.position, 0.5f);

            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = false;
            }

            if (itemHolding.GetComponent<DistractionInt>())
            {
                itemHolding.GetComponent<DistractionInt>().enabled = false;
            }
    }
*/
}




/*

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,.5f);
    }

    void UpdateTarget()
    {
        //loop through different enemies 
        //get array of all enemies 
        //find all enemies that are tagged and store tha in arraw
        GameObject[] enemies= GameObject.FindGameObjectsWithTag(enemyTag);
        //shortest distance to enemy that we have found so far 
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy=null;
        //loop through 
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy= Vector3.Distance(transform.position, enemy.transform.position);
            //found enemy closer
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance=distanceToEnemy;
                nearestEnemy=enemy;
            }
            if (nearestEnemy!=null && shortestDistance <=range)
            {
                target= nearestEnemy.transform;
                TestMovement script= nearestEnemy.GetComponent<TestMovement>();
                script.speed=0;
                Debug.Log(script.speed);
                StartCoroutine(Wait(nearestEnemy));
                
            }
            else{
                target=null;
            }
        }
    }

    */