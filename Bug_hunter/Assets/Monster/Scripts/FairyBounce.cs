using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBounce : MonoBehaviour
{
    public GameObject bouncing;
    public bool pushing;

    // 오디오용
    public AudioClip attack;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.clip = attack;
            audioSource.Play();
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
