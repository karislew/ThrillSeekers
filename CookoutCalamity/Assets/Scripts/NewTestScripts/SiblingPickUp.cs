using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SiblingPickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public AudioClip audiopickup;
    public AudioClip audiodrop;

    public Vector3 Direction { get; set; }

    private GameObject itemHolding;
    PlayerInputActions playerControls;
    private InputAction grab;
    public bool tableInteract = false;
    private GameObject pickUpItem;

  
   

    private void Awake()
    {
        playerControls = new PlayerInputActions();
       
    }
 

    private void OnEnable()
    {
        grab = playerControls.Player.PickUpKey;
        grab.Enable();
    }

    private void OnDisable()
    {
        grab.Disable();
    }

    void Update()
    {
        bool isEPressed = grab.triggered;
        //if (Input.GetKeyDown(KeyCode.E))
        if (isEPressed)
        {
            if (itemHolding)
            {
                
                DropItem();
            }
            else
            {
       
                PickUpItem();
            }
        }
    }

    
    void PickUpItem()
    {

        //Collider2D pickUpItem = Physics2D.OverlapCircle(drawCircle.transform.position + Direction, .4f, pickUpMask);
        //if (pickUpItem && pickUpItem.gameObject.tag == "Sibling")
        if(pickUpItem!=null)
        {
            
            Interactions interaction = pickUpItem.GetComponent<Interactions>();
            
            if (interaction != null && interaction.CanBePickedUp)
            {
                //itemHolding = pickUpItem.gameObject;
                itemHolding = pickUpItem;
                itemHolding.transform.position = holdSpot.position;
                itemHolding.transform.parent = transform;
                interaction.OnPickedUp();
                tableInteract=true;
               // tableInteract.siblingPickup==true;
                //itemHolding.GetComponent<Outline>().enabled = false;

                AudioSource.PlayClipAtPoint(audiopickup, transform.position, 0.5f);
            }
        }
    }
    
   
    void DropItem()
    {
        if (itemHolding != null)
        {
            itemHolding.transform.position = holdSpot.position + Direction;
            itemHolding.transform.parent = null;
            //itemHolding.GetComponent<Outline>().enabled = true;

            Interactions interaction = itemHolding.GetComponent<Interactions>();
            if (interaction != null)
            {
                interaction.OnDropped();

                AudioSource.PlayClipAtPoint(audiodrop, transform.position, 0.5f);
                tableInteract=false;
                //tableInteract.siblingPickup==false;
            }

            itemHolding = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sibling"))
        {
            pickUpItem = other.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Sibling"))
        {
            if(pickUpItem == other.gameObject)
            {
                pickUpItem = null;

            }

        }
    }

 

}
