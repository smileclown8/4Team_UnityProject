using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJump : MonoBehaviour
{

    public GameObject player;

    public float JumpForce = 110.0f;

    void Start()
    {


    }

    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))

                player.GetComponent<Rigidbody2D>().AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }
    }
}
