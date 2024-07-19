using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
   
    // Start is called before the first frame update
    //transform array 
    public static Transform[] points;

    void Awake()
    {
        //number of children that are currently under waypoints
        //array of 6 points
        //creating a certain amount of spaces
        points = new Transform[transform.childCount];
        
        //loop through them
        for (int i = 0;i<points.Length;i++)
        {
            //get child of the index of i (iterating through every child of the waypoints )
            //pushing that into the array using the index (i)
            //set the index to that child (getting list of all of the children)
            points[i]=transform.GetChild(i);
            

           
        }
    }
}
