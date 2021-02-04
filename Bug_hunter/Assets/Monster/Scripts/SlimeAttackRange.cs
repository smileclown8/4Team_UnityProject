using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackRange : MonoBehaviour
{
    // 공격용
    public Transform playerPos;
    public Transform myPos;
    public Rigidbody2D rigid;

    public float mass;
    public int speed = 2;
    public int jumpHeight = 20;
    public int backHeightX = 15;
    public int backHeightY = 35;


    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        rigid = GetComponentInParent<SlimeManager>().rigid;
        mass = GetComponentInParent<Rigidbody2D>().mass;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            myPos = GetComponentInParent<Transform>();
            JumpAttack();
            Invoke("BackDown", 0.25f);
        }
    }


    // 아래는 공격 피격용 아직 구현 안됨

    void JumpAttack()   // 몬스터의 공격
    {
        float distanceFromPlayer = playerPos.transform.position.x - transform.transform.position.x;

        rigid.AddForce(new Vector2(distanceFromPlayer * speed, jumpHeight), ForceMode2D.Impulse);
    }

    void BackDown()
    {
        if (myPos.position.x <= playerPos.position.x)
        {
            rigid.AddForce(new Vector2(-backHeightX, backHeightY), ForceMode2D.Impulse);
        }
        else if (myPos.position.x > playerPos.position.x)
        {
            rigid.AddForce(new Vector2(backHeightX, backHeightY), ForceMode2D.Impulse);
        }
    }
}