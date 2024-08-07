using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    public GameObject popUp;
    public GameObject triggerBox;
    public GameObject gameManager;
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
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tutorial")
        {
            popUp.SetActive(false);
            triggerBox.SetActive(false);
            gameManager.SetActive(true);
        }
    }
}
