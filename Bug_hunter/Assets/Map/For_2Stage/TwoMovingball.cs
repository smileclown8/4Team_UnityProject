using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoMovingball : MonoBehaviour
{
    public Transform startPos; //한쪽 끝
    public Transform endPos; // 다른쪽 끝

    public Transform desPos; //목적지

    public float PlatformMovespeed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "MovingBall")
        {
            desPos = endPos;
            rotSpeed = -rotSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "endpoint")
        {
            desPos = startPos;
            rotSpeed = -rotSpeed;
        }


    }
    void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;

        StartCoroutine(MovingPlatform());
    }

    public float rotSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }


    IEnumerator MovingPlatform()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime * PlatformMovespeed);
            yield return null;

        }
    }


}
