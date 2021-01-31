using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognitionManager : MonoBehaviour
{
    public GameObject target;
    public bool isTracing;


    // 추격
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTracing = false;
        }
    }

}
