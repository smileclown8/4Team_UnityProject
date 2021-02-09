using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGMController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip first;
    public AudioClip second;
    public AudioClip third;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.4f;
        audioSource.clip = first;
        audioSource.Play();
    }

}
