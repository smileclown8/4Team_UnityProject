using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxAttackSound : MonoBehaviour
{
    // 오디오용
    AudioSource audioSource;
    public AudioClip attackSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }

    public void MBAttackSound()
    {
        audioSource.clip = attackSound;
        audioSource.Play();
    }
}
