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

    /* 특정 시점부터 재생되게 하려면
     * 현재 Active 되어있지 않은 이 스크립트를, 재생시키고 싶은 부분에서 Active 시키면 됩니다! */
}
