using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackRange : MonoBehaviour
{
    // 공격용
    public Transform playerPos;
    public Transform myPos;
    public Rigidbody2D rigid;
    public Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        rigid = GetComponentInParent<SlimeManager>().rigid;
        playerPos = GameObject.FindWithTag("Player").transform;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            myPos = GetComponentInParent<Transform>();
            JumpAttack();
            Debug.Log("쩜프");
            Invoke("BackDown", 0.8f);
            Debug.Log("빽");
        }
    }


    // 아래는 공격 피격용 아직 구현 안됨

    void JumpAttack()   // 몬스터의 공격
    {
        float distanceFromPlayer = playerPos.transform.position.x - transform.transform.position.x;

        rigid.AddForce(new Vector2(distanceFromPlayer, playerPos.localScale.y * 7), ForceMode2D.Impulse);
    }

    void BackDown()
    {
        Debug.Log("1");
        if (myPos.position.x <= playerPos.position.x)
        {
            rigid.AddForce(new Vector2(GetComponentInParent<Rigidbody>().mass * -15, playerPos.localScale.y * 4), ForceMode2D.Impulse);
            Debug.Log("2");
        }
        else if (myPos.position.x > playerPos.position.x)
        {
            rigid.AddForce(new Vector2(GetComponentInParent<Rigidbody>().mass * 15, playerPos.localScale.y * 4), ForceMode2D.Impulse);
            Debug.Log("3");
        }
    }
}