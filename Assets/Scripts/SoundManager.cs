using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource audioSrc;
    public static AudioClip ZombieHitSound, FireSound, ReloadSound, ZombieDrbSound, walkSound, outOfAmmoSound,
        jumpSound, noReloadSound;
    static public SoundManager instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ZombieHitSound = Resources.Load<AudioClip>("ZombieHit");
        ZombieDrbSound = Resources.Load<AudioClip>("ZombiDrb");
        FireSound = Resources.Load<AudioClip>("Shoot");
        ReloadSound = Resources.Load<AudioClip>("Reload");
        walkSound = Resources.Load<AudioClip>("walk");
        outOfAmmoSound = Resources.Load<AudioClip>("OutOfAmmo");
        jumpSound = Resources.Load<AudioClip>("Jump");
        noReloadSound = Resources.Load<AudioClip>("NoReload");

        audioSrc = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        
        
        switch (clip)
        {
            case "Shoot":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "ZombiDrb":
                audioSrc.PlayOneShot(ZombieDrbSound);
                break;
            case "ZombieHit":
                audioSrc.PlayOneShot(ZombieHitSound);
                break;
            case "Reload":
                audioSrc.PlayOneShot(ReloadSound);
                break;
            case "walk":
                audioSrc.PlayOneShot(walkSound);
                break;
            case "OutOfAmmo":
                audioSrc.PlayOneShot(outOfAmmoSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "NoReload":
                audioSrc.PlayOneShot(noReloadSound);
                break;
        }   
    }
}
