using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstBoss;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.clip = firstBoss;
    }

    private bool isPlayed = false;

    private void Update()
    {
        if (GameObject.Find("Boss_CORE") != null)
        {
            if (!isPlayed)
                audioSource.Play();

            isPlayed = true;
        }
    }

}
