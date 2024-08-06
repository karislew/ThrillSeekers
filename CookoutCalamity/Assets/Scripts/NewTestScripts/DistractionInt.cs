using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionInt : MonoBehaviour
{
    private Transform target;
    public Transform siblingSpot;
    public Transform siblingPosition;
    private GameObject nearestEnemy = null;
    public PositionsManager positionsManager;
    public GameObject speechUI;
    public AudioClip arguing;

    public float range = 5f;
    public string enemyTag = "Enemy";

    private Interactions interactionScript;

    void Start()
    {
        speechUI.SetActive(false);
        interactionScript = GetComponent<Interactions>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(enemyTag))
        {
            if (target == null)
            {
                nearestEnemy = col.gameObject;
                target = nearestEnemy.transform;
                speechUI.SetActive(true);
                nearestEnemy.GetComponent<TestMovement>().enabled = false;
                interactionScript.SetPickUpState(false);

                if (target.transform.position != siblingSpot.transform.position)
                {
                    nearestEnemy.GetComponent<Rigidbody2D>().simulated = false;
                    target.transform.position = siblingSpot.transform.position;
                }

                StartCoroutine(Wait(nearestEnemy, siblingPosition));

                AudioSource.PlayClipAtPoint(arguing, transform.position, 0.5f);
            }
        }
    }

    IEnumerator Wait(GameObject nearestEnemy, Transform siblingPosition)
    {
        yield return new WaitForSeconds(5f);
        Destroy(nearestEnemy);
        speechUI.SetActive(false);
        target = null;
        transform.position = siblingPosition.position;
        interactionScript.SetPickUpState(true);
    }
}
