using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTableInt : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            Debug.Log("TABLE COLLIDED");
            Destroy(gameObject);
        }
    }
}
