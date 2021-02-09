using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 클레아 BGM
public class SecondCleaBGM : MonoBehaviour
{
    public AudioSource audioSource;
    bool BGMtrigger;

    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    void Update()
    {
        BGMtrigger = GetComponentInParent<SecondBossBGM>().BGMtrigger;
    }


    // 내면세계로 진입하면 자동 재생
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(BGMtrigger == true)
        {
            GetComponentInParent<AudioSource>().volume = 0.2f;      // 기본 볼륨 여기서 조절
            GetComponentInParent<AudioSource>().clip = GetComponentInParent<SecondBossBGM>().Clea;
            GetComponentInParent<AudioSource>().Play();
            GetComponentInParent<SecondBossBGM>().BGMtrigger = false;
        }
    }

    // 영상 나올 때는 꺼지도록 해놨습니다 (Boss_Clea_Crying.cs)
}
