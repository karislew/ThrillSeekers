using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepleteProgress : MonoBehaviour
{

    public Slider progressBar;
    //public GameObject enemyPrefab;
    public float decProgress = 3;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            StartCoroutine(Wait(col.gameObject,decProgress));
            
        }
    }
    IEnumerator Wait(GameObject enemy,float decProgress)
    {
        yield return new WaitForSeconds(.2f);
        DecProgress(decProgress);
        Destroy(enemy);
    }
    void DecProgress(float decProgress)
    {
        progressBar.value-=decProgress;
    }

}
