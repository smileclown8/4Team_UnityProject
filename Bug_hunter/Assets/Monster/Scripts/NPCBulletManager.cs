using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 강좌 https://youtu.be/kOzhE3_P2Mk

public class NPCBulletManager : MonoBehaviour
{
    int damage;
    [SerializeField] float speed = 6;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        damage = GameObject.Find("NPCmon").GetComponent<NPCmonManager>().attack;

        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, 0);
        Destroy(gameObject, 2);
    }


    // 플레이어에 닿으면 데미지를 주고 파괴
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStatusManager>().player_HP -= damage;
            Debug.Log("요정님 뿔났다~ 데미지 " + damage);
            Destroy(gameObject);
        }
    }


}
