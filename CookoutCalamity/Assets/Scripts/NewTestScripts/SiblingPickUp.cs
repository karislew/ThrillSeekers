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
    private SpriteRenderer rangeSpriteRenderer;


    // Update is called once per frame
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
            itemHolding = pickUpItem.gameObject;
            itemHolding.transform.position = holdSpot.position;
            itemHolding.transform.parent = transform;

            // Enable the range indicator
            rangeSpriteRenderer = itemHolding.transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (rangeSpriteRenderer != null)
            {
                rangeSpriteRenderer.enabled = true;
            }

            AudioSource.PlayClipAtPoint(audiopickup, transform.position, 0.5f);

            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = false;
            }

            if (itemHolding.GetComponent<DistractionInt>())
            {
                itemHolding.GetComponent<DistractionInt>().enabled = false;
            }
        }
    }

    void DropItem()
    {
        if (itemHolding != null)
        {
            itemHolding.transform.position = holdSpot.position + Direction;
            itemHolding.transform.parent = null;

            // Disable the range indicator
            if (rangeSpriteRenderer != null)
            {
                rangeSpriteRenderer.enabled = false;
            }

            if (itemHolding.GetComponent<Rigidbody2D>())
            {
                itemHolding.GetComponent<Rigidbody2D>().simulated = true;
            }

            if (itemHolding.GetComponent<DistractionInt>())
            {
                itemHolding.GetComponent<DistractionInt>().enabled = true;
            }

            itemHolding = null;
        }
    }
}
