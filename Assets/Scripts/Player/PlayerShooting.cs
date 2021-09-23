using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20; // повреждение от выстрела
    public float timeBetweenBullets = 0.15f; // время между выстрелами
    public float rang = 100f; // длина луча

    float timer;
    Ray shootRay;        // переменная типа луч
	RaycastHit shootHit; // переменная типа точка
	int shootableMask;   // слой для enemy
    ParticleSystem gunParticles; // ссылка на Partical sistem
    LineRenderer gunLine;   // Reference to the line renderer. ссылка на линию
    AudioSource gunAudio;   // Reference to the audio source.
    Light gunLight;         // Reference to the light component.
    float effectsDisplayTime = 0.2f; // The proportion of the timeBetweenBullets that the effects will display for.

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable"); // Reference to the layerMask "shootable
        gunParticles = GetComponent<ParticleSystem>();  // Подключам ParticleSystem
        gunLine = GetComponent<LineRenderer>(); // 
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    
    void Update()
    {
        timer += Time.deltaTime;// включам таймер, on timer

        if(Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        if(timer >= timeBetweenBullets * effectsDisplayTime)    //we will turn off the effects
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false; // turn off Line component
        gunLight.enabled = false; // turn off Light component
    }

    void Shoot()
    {
        timer = 0f;
        gunAudio.Play(); // on Sound shoot

        gunParticles.Play();
        gunParticles.Stop();
       
        
        gunLine.enabled = true; // Включаем линии, On Line
        gunLine.SetPosition(0, transform.position); // setting the starting point

        
        shootRay.origin = transform.position;//начальня точка луча, the startin point of the ray
        shootRay.direction = transform.forward; // установили направлени, rey direction
        
        // Условие на касания с enemy, the conition for the enemy touch
        if (Physics.Raycast(shootRay, out shootHit, rang, shootableMask)) 
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>(); // Refer
            if (enemyHealth != null)
            {
              enemyHealth.TakeDamage(damagePerShot, shootHit.point); // получаем ссылку на скрип EnemyHealth, включаем функцию
              //TakeDamage
            }
           
           
            gunLine.SetPosition(1, shootHit.point); // отрисовка линии до точки касания с enemy 
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * rang);// отрисовка линии длиной rang
        }
        
    }

}
