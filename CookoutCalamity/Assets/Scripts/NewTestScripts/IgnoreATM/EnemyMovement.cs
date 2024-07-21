using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4;
    
    private Transform target;
    private int waypointIndex= 0;


    void Start()
    {
        //referencing the points array
        //pursuing target with the waypoint index of zero
        target = Waypoints.points[0];
        //Debug.Log("Number" + number  + "Target" + Waypoints.points[0].position);
        
    } 

    //can try this with update
    
    void FixedUpdate()
    {
        //direction we have to point in order to get to waypoint
        Vector3 direction = target.position - transform.position;
        //move with this direction vector 
        //move the transform in the direction and distance of translation

        //make sure this will always have the same length
        transform.Translate(direction.normalized * speed * Time.deltaTime,Space.World);
        //rb.MovePosition(direction,)
        //if distance is less than .2 weve reached the waypoint
        if(Vector3.Distance(transform.position, target.position) <= .4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //the total amount of waypoints
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            //ensure it wont go down
            return;
        }
        //want the waypoint index to increase by 1 
        waypointIndex+=1;
        //calling the waypoints script with waypoints array and chaning it to the next waypoint index 
        target=Waypoints.points[waypointIndex];
    }
}
