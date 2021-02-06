using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EslafDeadSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip dead;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
