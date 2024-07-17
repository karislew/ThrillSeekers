using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    //enemy that we want to spawn (might need to make prefab)
    public Transform enemyPrefab;
    public Transform spawnPoint;


    //time between spawns 
    public float timeBetweenSpawns=5f;

    //time to spawn first 
    private float countdown=2f;

    private int waveIndex = 0;

    void Update()
    {
        //then start spawning (might have to change this to value that tells when enemy has been destroyed)
        if (countdown<= 0f)
        {
            StartCoroutine(SpawnEnemy());
            countdown = timeBetweenSpawns;
            
        }
        countdown-=Time.deltaTime;
    }
    //can wait x seconds before continuing 
    IEnumerator SpawnEnemy()
    {
        waveIndex=1;
        //++ to get more enemies 
        for (int i=0;i<waveIndex;i++)
        {
            //spawn after a few seconds if i wanted to spawn more than one enemy at a time 
            WaveSpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }


    }

    void WaveSpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
    }
    
}
