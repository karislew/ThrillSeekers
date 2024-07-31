using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiblingPickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public AudioClip audiopickup;

    public Vector3 Direction { get; set; }

    private GameObject itemHolding;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 0.4f, pickUpMask);
        if (pickUpItem)
        {
            Interactions interaction = pickUpItem.GetComponent<Interactions>();
            if (interaction != null && interaction.CanBePickedUp)
            {
                itemHolding = pickUpItem.gameObject;
                itemHolding.transform.position = holdSpot.position;
                itemHolding.transform.parent = transform;
                interaction.OnPickedUp();

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

            Interactions interaction = itemHolding.GetComponent<Interactions>();
            if (interaction != null)
            {
                interaction.OnDropped();
            }

            itemHolding = null;
        }
    }
}
