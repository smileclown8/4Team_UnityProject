using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBounce : MonoBehaviour
{
    public GameObject bouncing;
    public bool pushing;
    Animator pushinAnim;

    private void Start()
    {
        pushinAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pushing();
            pushing = true; // 밀어내는 효과 애니메이션 재생
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pushing = false;

        }
    }


    void Pushing()
    {
        Instantiate(bouncing, transform.position, Quaternion.identity);
    }

}
