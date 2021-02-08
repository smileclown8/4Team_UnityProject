using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitPattern : MonoBehaviour
{
    // Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // anim = gameObject.GetComponent<Animation>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("어억");
            //anim.Play("Rabbit1Pattern");
            GetComponent<Animator>().SetTrigger("RabbitHited");
        }
    }
}
