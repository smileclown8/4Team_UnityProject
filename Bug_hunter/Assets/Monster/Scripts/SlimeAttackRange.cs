using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackRange : MonoBehaviour
{
    // 공격용
    Transform playerPos;
    Transform myPos;
    Rigidbody2D rigid;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        rigid = GetComponentInParent<SlimeManager>().rigid;
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            myPos = GetComponent<Transform>();
            JumpAttack();
            Debug.Log("쩜프");
            Invoke("BackDown", 0.5f);
            Debug.Log("빽");
        }
    }


    // 아래는 공격 피격용 아직 구현 안됨

    void JumpAttack()   // 몬스터의 공격
    {
        float distanceFromPlayer = playerPos.position.x - transform.position.x;

        rigid.AddForce(new Vector2(distanceFromPlayer, playerPos.localScale.y * 4), ForceMode2D.Impulse);
    }

    void BackDown()
    {
        if (myPos.position.x < playerPos.position.x)
        {
            rigid.AddForce(new Vector2(-5, playerPos.localScale.y * 1.2f), ForceMode2D.Impulse);
        }
        else if (myPos.position.x > playerPos.position.x)
            rigid.AddForce(new Vector2(5, playerPos.localScale.y * 1.2f), ForceMode2D.Impulse);

    }
}