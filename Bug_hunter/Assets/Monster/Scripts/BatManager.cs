﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    bool isTracing;
    public GameObject bullet;
    float shoottime = 2;
    float nextshoot = 2;

    // 오디오용
    public AudioClip moving;
    AudioSource audioSource;
    bool isChattering;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isTracing = transform.parent.GetComponentInChildren<RecognitionManager>().isTracing;


        // 범위 안에 플레이어가 인식되면
        if (isTracing)
        {
            // 이동사운드 출력
            if (isChattering == false)
            {
                audioSource.volume = 0.6f;
                audioSource.clip = moving;
                audioSource.Play();
                isChattering = true;
            }

            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = false;       // 움직임을 멈추고
            Attack();                                                                     // 공격
        }
        // 놓치면
        else
        {
            audioSource.Stop();
            isChattering = false;

            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = true;        // 다시 움직이기 시작
        }
    }

    void Attack()
    {
        if (shoottime > nextshoot)
        {
            GenerateBullet();
            Invoke("GenerateBullet", 0.3f);     // 0.3초 간격을 두고 총알 두 번 발사
            shoottime = 0;
        }
        shoottime += Time.deltaTime;
    }

    void GenerateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

}
