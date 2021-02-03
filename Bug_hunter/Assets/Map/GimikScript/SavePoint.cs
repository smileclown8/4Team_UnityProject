using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public int here;

    public GameObject Flag_On;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "Player")
            {
                here++;
                this.gameObject.SetActive(false);
                Flag_On.SetActive(true);
            }
        
    }
}
