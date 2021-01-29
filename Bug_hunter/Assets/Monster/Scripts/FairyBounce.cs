using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBounce : MonoBehaviour
{

    public GameObject bouncing;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pushing();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Pushing", 3);
        }
    }

    void Pushing()
    {
        Instantiate(bouncing, transform.position, Quaternion.identity);
    }

}
