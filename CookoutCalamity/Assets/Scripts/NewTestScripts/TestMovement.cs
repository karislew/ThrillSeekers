using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    
    //array of points to walk from one place to another 
    public Transform[] waypoints;


    
    [SerializeField]
    public static TestMovement instance;
    public float speed=4;

    //index of current waypoint
    private int waypointIndex = 0;

    private Transform target;




   //private Transform[] waypoints; 



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //waypoints= WayPointManagement.waypoints;
        //set enemy to position of the first waypoint
        target= waypoints[waypointIndex];
    }

    void FixedUpdate()
    {
        {
        //direction we have to point in order to get to waypoint
        Vector3 direction = target.position - transform.position;
        //move with this direction vector 
        //move the transform in the direction and distance of translation

        //make sure this will always have the same length
        transform.Translate(direction.normalized * speed * Time.deltaTime,Space.World);
        //rb.MovePosition(direction,)
        //if distance is less than .2 weve reached the waypoint
        if(Vector3.Distance(transform.position, target.position) <= 1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //the total amount of waypoints
        if(waypointIndex >= waypoints.Length - 1)
        {
            //Destroy(gameObject);
            //ensure it wont go down
            return;
        }
        //want the waypoint index to increase by 1 
        waypointIndex+=1;
        //calling the waypoints script with waypoints array and chaning it to the next waypoint index 
        target=waypoints[waypointIndex];
    }
}

    }

   
