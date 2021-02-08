﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 스테이지1
public class Changer4 : MonoBehaviour
{
    bool isChanged;
    public bool thirdBGMtrigger;

    bool printingScripts;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChanged == false)
        {
            GameObject.Find("StageBGM").GetComponentInChildren<Changer3>().secondBGMtrigger = false;
            GetComponentInParent<AudioSource>().Stop();
            GetComponentInParent<AudioSource>().clip = GetComponentInParent<StageBGMController>().third;
            GetComponentInParent<AudioSource>().volume = 0.8f;
            GetComponentInParent<AudioSource>().Play();
            isChanged = true;
            thirdBGMtrigger = true;
        }
    }

    private void Update()
    {
        printingScripts = GameObject.FindWithTag("Player").GetComponent<PlayerController>().printingScripts;

        if (thirdBGMtrigger == true && printingScripts == false && GetComponentInParent<AudioSource>().volume != 0.8f)
        {
            GetComponentInParent<AudioSource>().volume = 0.8f;
        }
    }

}
