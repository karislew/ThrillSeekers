using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    //enemy that we want to spawn (might need to make prefab)
    //public GameObject enemyPrefab;
    //private Transform spawnPoint;

    public EnemyManagement enemyManagement;


    //time between spawns 
    public float timeBetweenSpawns=5f;
    public WayPointManagement waypointManager;

    //time to spawn first 
    private float countdown=3f;

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
        waveIndex=Random.Range(1,1);
        
        //++ to get more enemies 
        for (int i=0;i<waveIndex;i++)
        {
            //spawn after a few seconds if ai wanted to spawn more than one enemy at a time 
            WaveSpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }


    }

    void WaveSpawnEnemy()
    {
        Transform[] path = waypointManager.GetRandomPath();
        Transform spawnPoint= path[0];
        GameObject enemyPrefab = enemyManagement.GetRandom();
        GameObject enemy= Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
        
        enemy.GetComponent<TestMovement>().Initialize(path);
    }
    
}
