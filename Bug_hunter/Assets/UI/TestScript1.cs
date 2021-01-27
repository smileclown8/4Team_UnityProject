﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{

    BGMManager BGM;
    public int playMusicTrack;


    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        BGM.Play(playMusicTrack);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BGM.Stop();
        //this.gameObject.SetActive(false);
    }
}