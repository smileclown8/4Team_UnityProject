using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip main;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = main;
        audioSource.Play();
    }
}
