using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    public GameObject popUp;
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tutorial")
        {
            popUp.SetActive(true);
        }
    }
}
