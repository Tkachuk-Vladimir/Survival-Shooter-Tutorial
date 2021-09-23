using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovoment : MonoBehaviour
{
    Transform player;                 
    NavMeshAgent nav;

    PlayerHealth playerHealth; // доступ к скриптам
    EnemyHealth enemyHealth;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        // Если жив enemy и player то следовать за player
        if (enemyHealth.currentHealth > 0 &&  playerHealth.currentHealth > 0)

        {
            nav.SetDestination(player.position);// функция следования за player.position
        }
        // 
        else
        {
            //  disable the nav mesh agent, выключаем навигационную систему
            nav.enabled = false;
        }
    }
}
