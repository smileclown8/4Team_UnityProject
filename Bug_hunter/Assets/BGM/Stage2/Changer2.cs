using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer2 : MonoBehaviour
{
    bool isChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChanged == false)
        {
            GetComponentInParent<AudioSource>().Stop();
            GetComponentInParent<AudioSource>().clip = GetComponentInParent<StageBGMController>().third;
            GetComponentInParent<AudioSource>().volume = 0.3f;
            GetComponentInParent<AudioSource>().Play();
            isChanged = true;
        }
    }

}
