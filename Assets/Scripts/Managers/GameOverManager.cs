using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

    void Awake()
    {
       anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(playerHealth.currentHealth <= 0) // проверка мёртв ли player
        {
            anim.SetTrigger("GameOver"); // включаем анимацию GameOver
            restartTimer += Time.deltaTime; // включаем таймер
            if(restartTimer >= restartDelay) // 
            {    
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // перезагрузка текущего уровня
            }
        }
    }
}
