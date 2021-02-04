using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBulletManager : MonoBehaviour
{
    float hp;

    int damage;
    [SerializeField] float speed = 4;
    Rigidbody2D rb;

    Vector2 bookPos;
    Vector2 myPos;
    [SerializeField] float minRange;                         // 랜덤위치값1
    [SerializeField] float maxRange;                         // 랜덤위치값2
    [HideInInspector] public Vector2 randomBulletPosition;

    float distance;                                          // 총알과 본인 사이의 거리
    int destroySecond = 2;                                   // 총알이 파괴되기까지의 시간



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = GameObject.Find("Book").GetComponent<MonsterStatusManager>().attack;

        randomBulletPosition.x = Random.Range(-1.0f, 1.0f);
        randomBulletPosition.y = Random.Range(-1.0f, 1.0f);

        rb.velocity = new Vector2((transform.position.x + randomBulletPosition.x) * speed * 10 * Time.deltaTime,
                                  (transform.position.y + randomBulletPosition.y) * speed * 10 * Time.deltaTime);

        Destroy(gameObject, destroySecond);
    }

    void Update()
    {
        hp = GameObject.Find("Book").GetComponent<MonsterStatusManager>().hp;

        if (hp > 0)
        {
            bookPos = GameObject.Find("Book").GetComponent<Transform>().position;
            myPos = GetComponent<Transform>().position;
            distance = Vector2.Distance(bookPos, myPos);

            // 8의 범위를 넘어가면 파괴
            if (distance >= 8)
                Destroy(gameObject);
        }

    }


    // 플레이어에 닿으면 데미지를 주고 파괴
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= damage;
            Debug.Log("동화책의 노래! 데미지 " + damage);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "PlayerBullet")
            Destroy(gameObject);

    }
}
