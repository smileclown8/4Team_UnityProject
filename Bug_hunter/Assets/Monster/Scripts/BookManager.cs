using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    Animator anim;


    // 공격용
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    [SerializeField] GameObject bullet4;
    [SerializeField] GameObject bullet5;
    [SerializeField] float shoottime;       // 발사시간
    [SerializeField] float nextshoot;       // 쿨타임



    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        nextshoot = 5;
        shoottime = Random.Range(0, 6);
    }


    void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        // 쿨타임 돌 때마다 공격
        if (nextshoot <= shoottime)
        {
            GenerateBullet();
            shoottime = 0;
        }
        shoottime += Time.deltaTime;
    }

    void GenerateBullet()
    {
        // 랜덤한 종류의 음표를 발사한다.
        int RandomBullet = Random.Range(1, 6);
        switch (RandomBullet)
        {
            case 1:
                Instantiate(bullet1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(bullet2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(bullet3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(bullet4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(bullet5, transform.position, Quaternion.identity);
                break;
        }
    }

}
