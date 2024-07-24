using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public Transform[] waypoints2;

    public Transform[] waypoints3;

    public List<Transform[]> paths = new List<Transform[]>();

    void Awake()
    {
        paths.Add(waypoints);
        paths.Add(waypoints2);
        paths.Add(waypoints3);
    }
    
    public Transform[] GetRandomPath()
    {
        int randomIndex= Random.Range(0,paths.Count);
        return paths[randomIndex];
    }
    
}
