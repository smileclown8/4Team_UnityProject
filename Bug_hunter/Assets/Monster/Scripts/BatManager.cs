using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    // 스탯
    int hp = 10;
    [HideInInspector] public int attack = 2;
    int buffRate = 5;

    bool isTracing;
    public GameObject bullet;
    float shoottime = 2;
    float nextshoot = 2;



    void Update()
    {
        isTracing = transform.parent.GetComponentInChildren<RecognitionManager>().isTracing;


        // 범위 안에 플레이어가 인식되면
        if (isTracing)
        {
            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = false;       // 움직임을 멈추고
            Attack();                                                                     // 공격
        }
        // 놓치면
        else
        {
            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = true;        // 다시 움직이기 시작
        }



        // 사망 시 사라지기
        if (hp <= 0)
            Destroy(transform.parent.gameObject);       // 사망하면 부모 오브젝트부터 모두 삭제
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }


    void Attack()
    {
        if (shoottime > nextshoot)
        {
            GenerateBullet();
            Invoke("GenerateBullet", 0.3f);     // 0.3초 간격을 두고 총알 두 번 발사
            shoottime = 0;
        }
        shoottime += Time.deltaTime;
    }

    void GenerateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

}
