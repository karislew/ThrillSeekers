using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTableInt : MonoBehaviour
{
    //public Slider progressBar;
    public GameObject enemyPrefab;
    public float decProgress;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            StartCoroutine(Wait(decProgress));
        }
    }
    IEnumerator Wait(float decProgress)
    {
        yield return new WaitForSeconds(.2f);
        //depleteProgress.DepletePro(decProgress);
        Destroy(gameObject);

    }
    
}
