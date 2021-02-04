using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttackSound : MonoBehaviour
{
    // 오디오용
    AudioSource audioSource;
    public AudioClip attackSound;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.volume = 0.4f;
    }

    public void SAttackSound()
    {
        audioSource.clip = attackSound;
        audioSource.Play();
    }
}
