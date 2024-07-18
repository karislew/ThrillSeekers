using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionInt : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;

    public float range = 5f;
    public string enemyTag="Enemy";

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
            }
            else{
                target=null;
            }
        }
    }
    void Update()
    {
        if(target==null)
            return;

        target.transform.position=transform.position;
        /*
        Vector3 dir= target.position - transform.position;
        Quaternion lookRotation  = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation= Quaternion.Euler(0f,rotation.y,0f);
        */


    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
    
    
    
}
