using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostMemoryCount : MonoBehaviour
{

    GameObject controller;
    // Start is called before the first frame update
    public void Start()
    {
        controller = GameObject.Find("LostMemoryController");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.GetComponent<LostMemoryController>().count = controller.GetComponent<LostMemoryController>().count + 1;
            gameObject.SetActive(false);
        }

    }
}

