using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy1;
    public GameObject[] enemy2;
    public GameObject[] enemy3;
    public GameObject[] enemy4;
    public AudioClip mom;
    public AudioClip dad;
    public AudioClip aunt;
    public AudioClip uncle;
    

    public List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void Awake()
    {
        enemies.AddRange(enemy1);
        enemies.AddRange(enemy2);
        enemies.AddRange(enemy3);
        enemies.AddRange(enemy4);

    }
   
    public GameObject GetRandom()
    {
        int randomIndex = Random.Range(0,enemies.Count);
        /*if (randomIndex == 0)
            {
            Debug.Log("Play Mom");
            AudioSource mom = GetComponent<AudioSource>();
            mom.Play();
        }
        else if (randomIndex == 1)
        {
            AudioSource dad = GetComponent<AudioSource>();
            dad.Play();
            Debug.Log("father");
        }
        else if (randomIndex == 3)
        {
            AudioSource aunt = GetComponent<AudioSource>();
            aunt.Play();
            Debug.Log("aunt");
        }
        else if (randomIndex == 2)
        {
            AudioSource uncle = GetComponent<AudioSource>();
            uncle.Play();
            Debug.Log("uncle");
        }
        */

        return enemies[randomIndex];
    }
}
