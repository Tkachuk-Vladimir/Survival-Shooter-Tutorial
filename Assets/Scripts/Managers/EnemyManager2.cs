using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    public int SpawnTime;
    public int SpawnTimeRang;
    public GameObject Enemy;
    public Transform[] spawnPoint;
    public PlayerHealth playerHealth;

    float Timer;
    
    void Start()
    {
        Timer = 0f;
        SpawnTime = Random.Range(1, SpawnTimeRang);
    }

    
    void Update()
    {
        Timer += Time.deltaTime;

        if(Mathf.RoundToInt(Timer) == SpawnTime)
        {
            Spawn();
            Timer = 0f;
        }
    }

    void Spawn()
    {
        if (playerHealth.isDead == true)
            return;
       
        int spawnPointIndex = Random.Range(0, spawnPoint.Length);
        Instantiate(Enemy, spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation); //creates gameObjects
        SpawnTime = Random.Range(1, SpawnTimeRang);// generates a point again
    }
}
