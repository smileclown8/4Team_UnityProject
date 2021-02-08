using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer1 : MonoBehaviour
{
    bool isChanged;
    public bool secondBGMtrigger;

    bool printingScripts;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isChanged == false)
        {
            GetComponentInParent<AudioSource>().Stop();
            GetComponentInParent<AudioSource>().clip = GetComponentInParent<StageBGMController>().second;
            GetComponentInParent<AudioSource>().volume = 0.2f;
            GetComponentInParent<AudioSource>().Play();
            isChanged = true;
            secondBGMtrigger = true;
        }
    }

    private void Update()
    {
        printingScripts = GameObject.FindWithTag("Player").GetComponent<PlayerController>().printingScripts;

        if (secondBGMtrigger == true && printingScripts == false && GetComponentInParent<AudioSource>().volume != 0.2f)
        {
            GetComponentInParent<AudioSource>().volume = 0.2f;
        }
    }

}
