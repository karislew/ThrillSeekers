using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public bool CanBePickedUp { get; private set; } = true;
    private SpriteRenderer rangeSpriteRenderer;

    void Start()
    {
        rangeSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (rangeSpriteRenderer != null)
        {
            rangeSpriteRenderer.enabled = false; // Initially off
        }
    }

    public void SetPickUpState(bool canPickUp)
    {
        CanBePickedUp = canPickUp;
    }

    public void OnPickedUp()
    {
        // Enable the range indicator
        if (rangeSpriteRenderer != null)
        {
            rangeSpriteRenderer.enabled = true;
        }

        // Optionally, disable Rigidbody2D and other components
        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        // Disable the distraction script while being carried
        if (GetComponent<DistractionInt>())
        {
            GetComponent<DistractionInt>().enabled = false;
        }
    }

    public void OnDropped()
    {
        // Disable the range indicator
        if (rangeSpriteRenderer != null)
        {
            rangeSpriteRenderer.enabled = false;
        }

        // Re-enable Rigidbody2D and other components if necessary
        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().simulated = true;
        }

        // Re-enable the distraction script after being dropped
        if (GetComponent<DistractionInt>())
        {
            GetComponent<DistractionInt>().enabled = true;
        }
    }
}
