using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)]float ShootingVolume;
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume;
    static AudioPlayer instance;
    private void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if (instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayingShootingClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip,Camera.main.transform.position,ShootingVolume);
        }
    }
    public void PlayingDamageClip()
    {
        PlayClip(damageClip,damageVolume);
    }
    void PlayClip(AudioClip audio,float vol)
    {

        if (audio != null)
        {
            AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, vol);
        }
    }
}

