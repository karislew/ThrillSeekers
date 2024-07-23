using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy1;
    public GameObject[] enemy2;

    public List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void Awake()
    {
        enemies.AddRange(enemy1);
        enemies.AddRange(enemy2);
    }
    public GameObject GetRandom()
    {
        int randomIndex = Random.Range(0,enemies.Count);
        return enemies[randomIndex];
    }
}
