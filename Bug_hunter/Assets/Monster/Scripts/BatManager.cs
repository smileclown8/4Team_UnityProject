using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    // 스탯
    int hp = 10;
    int batDamage = 2;


    [SerializeField] public GameObject bullet;
    float shoottime;
    float nextshoot;
    Animator animator;


    void Start()
    {
        shoottime = 2f;
        nextshoot = Time.time;
    }


    // 사망 시 사라지기
    private void Update()
    {
        if (hp <= 0)
            Destroy(transform.parent.gameObject);       // 사망하면 부모 오브젝트부터 모두 삭제
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }


    GameObject target;
    GameObject bat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")   // 플레이어가 닿으면
        {
            target = other.gameObject;          // 타깃을 플레이어로 세팅
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = false;       // 움직임을 멈추고
            Attack();                                                                     // 공격

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")                                             // 트리거 반경에서 벗어나면
        {
            GameObject.Find("BatMoving").GetComponent<MoveReply>().enabled = true;        // 다시 움직이기 시작
        }
    }


    void Attack()
    {
        if (Time.time > nextshoot)
        {
            GenerateBullet();
            Invoke("GenerateBullet", 0.3f);     // 0.3초 간격을 두고 총알 두 번 발사
            nextshoot = Time.time + shoottime;
        }
    }

    void GenerateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

}
