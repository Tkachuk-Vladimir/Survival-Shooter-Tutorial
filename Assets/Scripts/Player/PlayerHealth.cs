using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100; // начальный уровень жизни
    public int currentHealth; // текущий уровень жизни(в данный момент)
    public Slider healthSlider; // переменная типа слайдер
    public Image damageImage;   // переменная типа картинка
    public AudioClip deathClip; // переменная типа аудио клип
    public float flashSpeed = 5f; // скорость включения картинки при повреждении
    public Color flashColour = new Color(1f,0f,0f,0.1f); // переменная типа цвет

    Animator anim;  // переменная типа анимация
    AudioSource playerAudio; // переменная типа аудиоплеер
    PlayerMovement playerMovement; //  переменная для доступа в код PlayerMovement
    PlayerShooting playerShooting;

    public bool isDead;
    bool damaged;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = this.gameObject.transform.GetChild(1).GetComponent<PlayerShooting>();// получам досту к дочернему обекту и скрипту

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged) // если повредили 
        {
         damageImage.color = flashColour; // включаем красную картинку повреждения
        }
        else
        {
         damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime); // если нет выкл картинку(обезцветили)
        }
        damaged = false;
    }
    public void TakeDamage(int amount)
    {
        damaged = true; // включаем красную картинку повреждения
        currentHealth -= amount; // вычетаем из жизни
        healthSlider.value = currentHealth; // отрисовываем слайдер
        playerAudio.Play(); // включаем звук повреждения

        if(currentHealth <= 0 && !isDead) // делаем проверку на количесво жизней
        {
            Death(); // если жизни на нуле, включаем функцию смерти 
        }
    }
    void Death()
    {
        isDead = true;
        anim.SetTrigger("die"); // включеам анимацию смерти
        playerAudio.clip = deathClip; // подключаем звук смерти
        playerAudio.Play(); // включаем звук смерти
        playerMovement.enabled = false; // выключам скрипт движения
        playerShooting.enabled = false; // выключаем скрипт стрельбы

    }
}
