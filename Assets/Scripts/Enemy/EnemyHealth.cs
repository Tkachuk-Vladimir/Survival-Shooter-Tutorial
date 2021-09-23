using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100; 
    public int currentHealth;
    public float sinkSpeed = 2.5f; // скорость падения
    public int scoreValue = 10; //
    public AudioClip deathClip; // звук смерти зомбани

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticle;
    CapsuleCollider capsuleCollider;

    bool isDead;
    bool isSinking;


    // инициализация, получение доступа к свойства зомбани 
    void Awake()
    {
        anim = GetComponent<Animator>();                    // доступ к аниматор, доступ к управлению анимациями
        enemyAudio = GetComponent<AudioSource>();           // доступ аудио про
        hitParticle = GetComponent<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth; 
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        
        enemyAudio.Play();                          // включам звук урона
        currentHealth -= amount;                    // вычисляем текущую жизнь
        hitParticle.transform.position = hitPoint;  // перемещаем hitParticle в точку попадания 
        hitParticle.Play();                         // включаем  hitParticle

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;                      // 
        capsuleCollider.isTrigger = true;   // колайдер переводим в состаяние тригер, уже не тврёрдое тело
        anim.SetTrigger("Dead");            // включаем анимацию смерти
        enemyAudio.clip = deathClip;        // подключаем звук смерти   
        enemyAudio.Play();                  // включам звук смерти
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false; // выключаем навигацию, enemy не будет идти за player
        GetComponent<Rigidbody>().isKinematic = true; // выключам обработку физики
        isSinking = true;                               
        Destroy(gameObject, 2f);                      // удаляем enemy через 2 сек
        ScoreManager.score += scoreValue;

    }
}
