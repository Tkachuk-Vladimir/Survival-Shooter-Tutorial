using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;      
    public GameObject enemy;                            
    public Transform[] spawnPoints;

    public float Timer;
    public int SpawnTime;
    public int SpawnTimeRange;

     void Start()
     {
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        SpawnTime = Random.Range(1, SpawnTimeRange);
        Timer = 0f;
     }
    
    void Update()
    {
        Timer += Time.deltaTime;

        if (Mathf.RoundToInt(Timer) == SpawnTime)
        {        
            Spawn();
            Timer = 0f;
        }     
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f) //  будут появляться enemy пока жив player
        { 
            return;
        }  
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        SpawnTime = Random.Range(1, SpawnTimeRange);
    }
}