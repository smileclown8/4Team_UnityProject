using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    // 스탯
    int hp = 15;
    int attack = 15;
    int dodgeRate = 10;


    Rigidbody2D rigid;
    public int nextMove;
    GameObject target;
    bool isTracing;
    string direction = "";
    public float movePower = 1f;
    Vector3 moveVelocity = Vector3.zero;
    Animator anim;
    float timer = 3f;
    bool isFast;

    // 데미지 연결
    float playerHP;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHP = GameObject.Find("PlayerStatusManager").GetComponent<PlayerStatusManager>().player_HP;
    }

    void Start()
    {
        Invoke("Think", 1);

    }

    void FixedUpdate()
    {

        // 패트롤
        if (!isTracing)
        {
            if (isFast)
            {
                if (timer > 0)
                {
                    movePower = 4f;
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        isFast = false;
                        timer = 3f;
                    }
                }
            }
            else
            {
                movePower = 1f;
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    isFast = true;
                    timer = 1f;
                }
            }
            rigid.velocity = new Vector2(nextMove*movePower, rigid.velocity.y);


            // 추락방지
            Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.7f, rigid.position.y);
            Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider == null)
            {
                nextMove *= -1;
                CancelInvoke();
                Invoke("Think", 3);
            }
        }


        // 추격
        target = GetComponentInChildren<RecognitionManager>().target;
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;
        if (isTracing)
        {
            movePower = 2f;
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
                direction = "Left";
            else if (playerPos.x > transform.position.x)
                direction = "Right";

            transform.position += moveVelocity * movePower * Time.deltaTime;

        }
        else
        {
            if (nextMove == -1)
                direction = "Left";
            else if (nextMove == 1)
                direction = "Right";
        }

        // 플립
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

    }
    // 패트롤 방향을 3초마다 생각
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
    }



    float delaytime = 1f;
    float attacktime = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            playerHP -= attack;
            Debug.Log("콰삭!");
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > attacktime)
            {
                playerHP -= attack;
                Debug.Log("콰삭콰삭!");

                attacktime = Time.time + delaytime;
            }
        }
    }
}
