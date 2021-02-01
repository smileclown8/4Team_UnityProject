using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBulletManager : MonoBehaviour
{
    int damage;
    public float speed;
    Rigidbody2D rb;

    Vector2 target;
    Vector2 moveDirection;

    Vector2 bookPos;
    Vector2 myPos;
    [SerializeField] float minRange;                         // 랜덤위치값1
    [SerializeField] float maxRange;                         // 랜덤위치값2
    float randomX;
    float randomY;
    [HideInInspector] public Vector2 randomBulletPosition;
    float distance;

    int destroySecond = 2;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        damage = GameObject.Find("Book").GetComponent<BookManager>().attack;

        randomBulletPosition.x = Random.Range(-1.0f, 1.0f);
        randomBulletPosition.y = Random.Range(-1.0f, 1.0f);

        rb.velocity = new Vector2((transform.position.x + randomBulletPosition.x) * speed * 10 * Time.deltaTime,
                                  (transform.position.y + randomBulletPosition.y) * speed * 10 * Time.deltaTime);

        Destroy(gameObject, destroySecond);
    }

    void Update()
    {
        bookPos = GameObject.Find("Book").GetComponent<Transform>().position;
        myPos = GetComponent<Transform>().position; 
        distance = Vector2.Distance(bookPos, myPos);

        // 8의 범위를 넘어가면 파괴
        if (distance >= 8)
            Destroy(gameObject);
    }


    // 플레이어에 닿으면 데미지를 주고 파괴
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStatusManager>().player_HP -= damage;
            Debug.Log("Hit!" + damage + " 받음");
            Destroy(gameObject);
        }
    }
}
