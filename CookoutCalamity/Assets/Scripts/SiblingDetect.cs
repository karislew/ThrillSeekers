using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiblingDetect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    Transform[] endpoints;
    private int waypointIndex = 0;

    public float moveSpeed=2f;
   
     private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<FollowThePath>().StopMovement();
            StartCoroutine(Wait());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           other.GetComponent<FollowThePath>().ReturnMovement();
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        transform.position= endpoints[waypointIndex].transform.position;
        //Debug.Log("About to move");
        Move();
        //transform.position= Vector3.MoveTowards(transform.position,endpoints[0].transform.position,moveSpeed*Time.deltaTime);
    }

    private void Move()
    {
       //Debug.Log("Trying to Moves");
    

        //if enemy didnt reach end of waypoint it can move 
        //if enemy reached last waypoint then it stops 
        if (waypointIndex<=endpoints.Length - 1)
        {
            //move enemy from current waypoint to the next 
            
            transform.position= Vector3.MoveTowards(transform.position,
            endpoints[waypointIndex].transform.position,
            moveSpeed*Time.deltaTime);
            

            //if enemy reached position where he can walk towards then waypoint is increased by one 

        
            
        
            if(transform.position == endpoints[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
        } 
       
       
        
    }
    // Update is called once per frame
   
}
