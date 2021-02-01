using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    // 스탯
    public int hp = 20;
    public int attack = 20;
    public int defense = 5;
    int buffRate = 20;

    Animator anim;
    SpriteRenderer spriteRenderer;


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




    // 체력 0 이하일 때 피격효과 내고 사라진다.
    public void OnDamaged(int damage)
    {
        if (hp <= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);        // 맞으면 반투명해짐
            Invoke("Destroy", 1.5f);                                // 1.5초 뒤 사라짐
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
