using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSibling : MonoBehaviour
{
    public TestTriggers pickupTrigger;
    public TestTriggers detectEnemyTrigger;

    void Awake()
    {
        pickupTrigger.EnteredTrigger += OnPickupTriggerEntered;
        pickupTrigger.ExitedTrigger += OnPickupTriggerExited;
        detectEnemyTrigger.EnteredTrigger += OnDetectEnemyTriggerEntered;
        detectEnemyTrigger.ExitedTrigger += OnDetectEnemyTriggerExited;
    }


    void OnPickupTriggerEntered(Collider2D col)
    {
        Debug.Log("HEY I Entered pick up range" + col.name);
        
    }
    void OnPickupTriggerExited(Collider2D col)
    {
        Debug.Log("HEY I Exited pick up range" + col.name);
        
    }
    void OnDetectEnemyTriggerEntered(Collider2D col)
    {
        Debug.Log("HEY I Entered detect range" + col.name);

    }
    void OnDetectEnemyTriggerExited(Collider2D col)
    {
        Debug.Log("HEY I Exited detect range" + col.name);
    }
}
