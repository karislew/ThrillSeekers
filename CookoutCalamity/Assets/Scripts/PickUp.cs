using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;

    //using getters and setters
    public Vector3 Direction{ get;set; }

    //want to access when you need to drop
    private GameObject itemHolding;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {

        //check for key input

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(itemHolding)
            {
                //placed in from of player
                itemHolding.transform.position = (holdSpot.transform.position + Direction);
                itemHolding.transform.parent =null;
                if(itemHolding.GetComponent<Rigidbody2D>())
                {
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                    itemHolding =  null;
                }
            }

                //player position and direction (mag of 1), radius , mask to get items
                //returns collider 2d
            else{
                Collider2D pickUpItem = Physics2D.OverlapCircle(holdSpot.transform.position + Direction, 1f, pickUpMask);
                if(pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    //set parent of that item to player so it will move along with it 
                    itemHolding.transform.parent = transform;

                    if(itemHolding.GetComponent<Rigidbody2D>())
                    {
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                    }
                }
            }
            
        }
    }
}