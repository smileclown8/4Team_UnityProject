using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeManager : MonoBehaviour
{
    int attack;
    public float speed = 1f;

    // 이동 및 추격용
    Vector3 movement;
    int movementFlag = 0;   // 0: 정지상태, 1: 좌이동, 2: 우이동
    bool isTracing;
    public GameObject target;
    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    new BoxCollider2D collider;



    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attack = GetComponent<MonsterStatusManager>().attack;
    }

    void Start()
    {
        StartCoroutine("ChangeMovement");
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        yield return new WaitForSeconds(3f);

        StartCoroutine("ChangeMovement");
    }


    void FixedUpdate()
    {
        Move();
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;
        target = GetComponentInChildren<RecognitionManager>().target;
    }


    // 이동용 함수
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string direction = "";

        if (isTracing)
        {
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                direction = "Left";
            else if (playerPos.x > transform.position.x)
                direction = "Right";
        }
        else
        {
            if (movementFlag == 1)
                direction = "Left";
            else if (movementFlag == 2)
                direction = "Right";
        }

        // 왼쪽 오른쪽 이동
        if (direction == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * speed * Time.deltaTime;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")             // 플레이어의 총알에 닿으면
        {
            rigid.AddForce(Vector2.up * 8, ForceMode2D.Impulse);    // 맞으면 위로 약간 튀어오름
            // 데미지 계산은 MonsterStatusManager가 해줄것
        }

        if (collision.gameObject.tag == "Player")                   // 플레이어와 닿으면
        {
            GameObject.Find("Manager").GetComponentInChildren<PlayerStatusManager>().player_HP -= attack; // 충돌 시 데미지를 준다
            // 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
            Debug.Log("슬라임의 공격! 데미지 " + attack);
        }
    }

}
