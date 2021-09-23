using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f; // время между атаками
    public int attackDamage = 10;           // количество повреждений

    Animator anim;  // переменная типа анимация
    GameObject player; // создаём пустую переменную типа gameObject
    PlayerHealth playerHealth; // создаюм ссылку на скрипт playeHealth
   //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime; // включаем таймер

        if(playerInRange && timer >= timeBetweenAttacks /*&& enemyHealth.currentHealth > 0*/)// услови если enemy рядом приченять
        {
            Attack();
        }
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }
    void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)// если у player есть жизни, то наносим ему урон
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
