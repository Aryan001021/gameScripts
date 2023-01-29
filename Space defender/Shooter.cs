using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool isFiring;
    [SerializeField] bool usedByAI;
    [SerializeField] GameObject projectile;
    [SerializeField] int projectileSpeed = 10;
    [SerializeField] int projectileLifePeriod = 5;
    Coroutine FireProjectile;
    [SerializeField] float FiringRate = 0.2f;
    AudioPlayer audioPlayer;
    private void Awake()
    {
        audioPlayer=FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (usedByAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && FireProjectile==null)
        {
            FireProjectile = StartCoroutine(FireContinously());
        }
        else if(!isFiring && FireProjectile!=null)
        {
            StopCoroutine(FireContinously());
            FireProjectile=null;
        }
    }
    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position,
                Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (usedByAI)
                {
                    rb.velocity = -transform.up * projectileSpeed;
                }
                if (!usedByAI)
                {
                    rb.velocity = transform.up * projectileSpeed;
                }
            }
            audioPlayer.PlayingShootingClip();
            Destroy(instance,projectileLifePeriod);
            yield return new WaitForSeconds(FiringRate);
        } 
    }
}
