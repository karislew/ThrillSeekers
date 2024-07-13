using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField]
    //array of points to walk from one place to another 
    private Transform[] waypoints;

    [SerializeField]
    //array of points to walk from one place to another 
    private Transform[] endpoints;

    
    [SerializeField]
    public static FollowThePath instance;
    public float moveSpeed=3f;

    //index of current waypoint
    private int waypointIndex = 0;
    private int waypointIndex2 = 0;

   

    private bool isStopped=false;
    private bool isDis=true;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
      
        //set enemy to position of the first waypoint
        transform.position= waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        SecondMove();
        
        
    }

    private void Move()
    {
        if(isStopped)
             return;
    

        //if enemy didnt reach end of waypoint it can move 
        //if enemy reached last waypoint then it stops 
           if (waypointIndex<=waypoints.Length - 1)
        {
            //move enemy from current waypoint to the next 

           // Debug.Log("transform.position before" + transform.position);
            //Debug.Log("points position before" + waypoints[waypointIndex].position);
            
            transform.position= Vector3.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed*Time.deltaTime);

            //Debug.Log("transform.position after" + transform.position);
            //Debug.Log("points position after" + waypoints[waypointIndex].position);
            

            //if enemy reached position where he can walk towards then waypoint is increased by one 

        
            
        
            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex++;
            }
            if(waypointIndex==waypoints.Length)
            {
                StartCoroutine(Waiting());
                //transform.position= Vector3.MoveTowards(transform.position,endpoints[0].transform.position, moveSpeed*Time.deltaTime);
                
                
                
                //transform.position= Vector3.MoveTowards(transform.position,waypoints[waypointIndex].transform.position, moveSpeed*Time.deltaTime);
                
            }
        }
    
      
        
       
       
        
    }
    
   

    
   
    private IEnumerator Waiting()
    {   
        
        yield return new WaitForSeconds(4);
        waypointIndex=0;
    }
    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3);
       // Debug.Log("position" + transform.position);
        transform.position= endpoints[waypointIndex].transform.position;
        SecondMove();

        //isStopped=true;
        //transform.position= Vector3.MoveTowards(transform.position,endpoints[0].transform.position,moveSpeed*Time.deltaTime);
       

    }
    
    public void StopMovement()
    {
        //Debug.Log("waypoint index" + waypointIndex);
        
        isStopped=true;
        //Debug.Log("Gonna disappear");
        //StartCoroutine(Disappear());
    }
    public void ReturnMovement()
    {
        isDis=false;
        isStopped=false;
        waypointIndex=0;
        Move();
       
    }
    private void SecondMove()
    {
        if(isDis)
            return;
        //Debug.Log("In second move" + waypointIndex + endpoints.Length);
    

        //if enemy didnt reach end of waypoint it can move 
        //if enemy reached last waypoint then it stops 

    
        if (waypointIndex2<=endpoints.Length - 1)
        {
            //move enemy from current waypoint to the next 

            //Debug.Log("transform.position before" + transform.position);
            //Debug.Log("points position before" + endpoints[waypointIndex2].position);
            //Debug.Log("moveSpeed" + moveSpeed);
            
            transform.position= Vector3.MoveTowards(transform.position,endpoints[waypointIndex2].transform.position, moveSpeed*Time.deltaTime);

           // Debug.Log("transform.position after" + transform.position);
           // Debug.Log("points position after" + endpoints[waypointIndex].position);
            

            //if enemy reached position where he can walk towards then waypoint is increased by one 

        
            
        
            if(transform.position == endpoints[waypointIndex2].transform.position)
            {
                waypointIndex2++;
            }
        } 

        /*
        if(waypointIndex2==endpoints.Length)
            {
                isStopped=false;
                StartCoroutine(Waiting());
                Move();
                //transform.position= Vector3.MoveTowards(transform.position,endpoints[0].transform.position, moveSpeed*Time.deltaTime);
                
                
                
                //transform.position= Vector3.MoveTowards(transform.position,waypoints[waypointIndex].transform.position, moveSpeed*Time.deltaTime);
                
            }
       */
       
        
    }
}
