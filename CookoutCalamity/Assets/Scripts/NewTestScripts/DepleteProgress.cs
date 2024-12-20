using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepleteProgress : MonoBehaviour
{
   
    public Slider progressBar;
    //public GameObject enemyPrefab;
    //public float decProgress = 3;
    private AudioSource table_sfx;
    public AudioClip swipe;

    private void Awake()
    {
        table_sfx = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TestMovement enemy = col.gameObject.GetComponent<TestMovement>();
            Debug.Log("Deplete value" + enemy.deplete + col.gameObject.name);
            StartCoroutine(Wait(col.gameObject, enemy.deplete));
            if(table_sfx==null)
            {
                Debug.Log("IN THIS PUSST");
            }else

            {
                Debug.Log("AUDIO SUPPOSED TO PLAH IG");
                table_sfx.PlayOneShot(swipe);}
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
