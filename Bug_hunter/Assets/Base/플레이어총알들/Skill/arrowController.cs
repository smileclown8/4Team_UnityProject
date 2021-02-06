using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float speed;
    

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 0.3f); //총알이 만들어지고 4초 후 파괴됨

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.rotation.y == 0) //플레이어가 오른쪽바라보면 오른쪽발사
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else //그 반대면 왼쪽 발사
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
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
