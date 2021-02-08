using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBGMController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip first;             // 볼륨비율 100
    public AudioClip second;            // 볼륨비율 30
    public AudioClip third;             // 볼륨비율 15


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
        audioSource.clip = first;
        audioSource.Play();
    }

}
