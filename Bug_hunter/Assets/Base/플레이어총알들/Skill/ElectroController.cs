using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 0.5f);
    }

    void Update()
    {
        int random = Random.Range(-1, 1 + 3);
        int Ran = Random.Range(-5, 1 +5);

        if (transform.rotation.y == 0) //플레이어가 오른쪽바라보면 오른쪽발사
        {
            transform.Translate(transform.right * Ran * speed * Time.deltaTime);
            transform.Translate(transform.up * random * speed * Time.deltaTime);
        }
        else //그 반대면 왼쪽 발사
        {
            transform.Translate(transform.right * Ran * speed * Time.deltaTime);
            transform.Translate(transform.up * random * speed * Time.deltaTime);

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
