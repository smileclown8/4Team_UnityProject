using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    GameObject Lever_off;
    public GameObject Lever_on;
    GameObject Lock_off;
    GameObject Door_close;
    public GameObject Door_open;


    // Start is called before the first frame update
    void Start()
    {
        Lever_off = GameObject.Find("Lever_off");
        Lock_off = GameObject.Find("Lock");
        Door_close = GameObject.Find("Door_close");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Door_open)
            {
                Door_open.SetActive(true);
            }
            if (Lever_on)
            {
                Lever_on.SetActive(true);
            }
            if (Lock_off)
            {
                Lock_off.SetActive(false);
            }
            if (Door_close)
            {
                Door_close.SetActive(false);
            }
            if (Lever_off)
            {
                Lever_off.SetActive(false);
            }
        }
    }
}
