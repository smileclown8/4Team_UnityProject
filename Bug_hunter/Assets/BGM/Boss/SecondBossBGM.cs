using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 인형 BGM
public class SecondBossBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Doll;
    public AudioClip Clea;
    public bool BGMtrigger;

    private void Start()
    {
        BGMtrigger = false;
    }

    // 1. 들어갔을 때 재생
    // 2. 내면세계에서 돌아오면 자동 재생
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BGMtrigger == false)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = 1;      // 기본 볼륨 여기서 조절
            audioSource.clip = Doll;
            audioSource.Play();
            BGMtrigger = true;
        }
    }


    // 재생 시작지점 활용방법은 1보스씬과 같음
}
