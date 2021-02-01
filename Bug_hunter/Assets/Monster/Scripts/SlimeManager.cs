using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 필요한 기능
 * 특정 함수 한번만 실행
 * aiPath 컴포넌트 끄기/켜기
 * 점프해서 공격
 * 애니메이션 전환
 * 
 */


public class SlimeManager : MonoBehaviour
{
    // 스탯
    int hp = 10;
    int attack = 5;

    public float speed = 1f;

    // 이동 및 추격용
    Vector3 movement;
    int movementFlag = 0;   // 0: 정지상태, 1: 좌이동, 2: 우이동
    bool isTracing;
    public GameObject target;
    public Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    new CapsuleCollider2D collider;



    // ===============================================================


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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


    


    // 체력 0 이하일 때 피격효과 내고 사라진다.
    public void OnDamaged(int damage)
    {
        if (hp <= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);        // 맞으면 반투명해짐
            collider.enabled = false;                               // 충돌 끄기
            rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);    // 위로 튀어오름
            Invoke("Destroy", 1.5f);                                // 1.5초 뒤 사라짐
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
