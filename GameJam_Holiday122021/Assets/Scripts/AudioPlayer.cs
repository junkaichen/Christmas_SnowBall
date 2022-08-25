using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BGM Setting
public class AudioPlayer : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [SerializeField] [Range(0f, 1f)] float backGroundVolume = 1f;

    [Header("BackGroundMusic")]
    [SerializeField] AudioClip backGroundSFX;

    // Background SFX
    void Start()
    {
        AudioSource.PlayClipAtPoint(backGroundSFX, Camera.main.transform.position, backGroundVolume);
    }

    // Hitting Present SFX
    public void PlayShootingClip()
    {
        AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    }


}
