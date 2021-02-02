using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public GameObject Lever_off;
    public GameObject Lock_off;
    public GameObject Door_close;
    public GameObject Door_open;
    public GameObject Lever_on;


    // Start is called before the first frame update
    void Start()
    {

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
