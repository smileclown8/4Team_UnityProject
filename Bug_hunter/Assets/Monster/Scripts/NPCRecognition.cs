using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRecognition : MonoBehaviour
{
    [SerializeField] GameObject target;
    public bool isTracing;
    bool isDamaged;
    public bool missing;



    void Update()
    {
        isDamaged = GetComponentInParent<NPCmonManager>().isDamaged;
        target = GetComponentInParent<NPCmonManager>().target;
    }

    // 추격
    void OnTriggerEnter2D(Collider2D other)
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isDamaged == true)
        {
            isTracing = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //missing = true;
            GetComponentInParent<NPCmonManager>().target = null;
            GetComponentInParent<NPCmonManager>().isDamaged = false;
            isTracing = false;
        }
    }
}
