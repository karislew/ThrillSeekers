using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePickUp : MonoBehaviour
{
    public GameObject[] dialogue;
    public GameObject popupE;
    private int index=0;
    // Start is called before the first frame update
    void Start ()
    {
        dialogue[0].SetActive(true);
        dialogue[1].SetActive(false);
        dialogue[2].SetActive(false);
        dialogue[3].SetActive(false);
        dialogue[4].SetActive(false);
 
        popupE.SetActive(false);



    }
    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.tag=="Tutorial")
        {
            Debug.Log("Will Play the dialogue");
            popupE.SetActive(true);
           

        }
    }
   
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {

            while(index!=dialogue.Length){
                index++;

                Debug.Log("Index"+ index);
                Debug.Log("Dialogue length" + dialogue.Length);

                if(index==1)
                {
                    dialogue[0].SetActive(false);
                    dialogue[index].SetActive(true);

                }
                else if(index==2)
                {
                    dialogue[0].SetActive(false);
                    dialogue[1].SetActive(false);
                    dialogue[index].SetActive(true);
                }
                else if(index==3)
                {
                    dialogue[0].SetActive(false);
                    dialogue[1].SetActive(false);
                    dialogue[2].SetActive(false);
                    dialogue[index].SetActive(true);
                }
                else if(index==4)
                {
                    Debug.Log("In the fourth index");
                    dialogue[0].SetActive(false);
                    dialogue[1].SetActive(false);
                    dialogue[2].SetActive(false);
                    dialogue[3].SetActive(false);
                    dialogue[index].SetActive(true);
                }
            }
        }
        
        
    }
}
