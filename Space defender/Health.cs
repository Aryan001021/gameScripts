using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    AudioPlayer audioPlayer;
    CameraShake cameraShake;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cameraShake=Camera.main.GetComponent<CameraShake>();
        levelManager=FindObjectOfType<LevelManager>();
    }
    public int GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayingDamageClip();
            ShakeCamera1();
            damageDealer.Hit();
        }
    }

    private void ShakeCamera1()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       if (!isPlayer && scoreKeeper!=null)
       {
            scoreKeeper.ModifyScore(score);
       }

        Destroy(gameObject);
        if (isPlayer)
        {
            levelManager.LoadGameOver();
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance=Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);   
        }
    }

    
}
