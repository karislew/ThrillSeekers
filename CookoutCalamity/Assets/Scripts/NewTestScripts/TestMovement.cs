using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Animator animator;
    //public Rigidbody2D rb;

    //array of points to walk from one place to another 
    private Transform[] waypoints;
    
    [SerializeField]
    public static TestMovement instance;
    public float speed=4;
    public float deplete = 10f;
    private Vector2 movement;

    //index of current waypoint
    private int waypointIndex = 0;
    private Vector3 direction;

    private Transform target;




   //private Transform[] waypoints; 

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Initialize(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        target = waypoints[waypointIndex];
    }

    // Start is called before the first frame update

    void Update()
    {
        movement = transform.position;
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

        }
    }

    void FixedUpdate()
    {
        {
        //direction we have to point in order to get to waypoint
        direction = target.position - transform.position;
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

   
