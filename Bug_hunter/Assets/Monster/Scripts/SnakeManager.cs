using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    // 이동용
    Rigidbody2D rigid;
    public int nextMove;
    GameObject target;
    bool isTracing;
    string direction = "";
    public float speed = 1f;
    Vector3 moveVelocity = Vector3.zero;
    float timer = 3;
    bool isFast;

    // 공격용
    float delaytime = 0;
    float attacktime = 1f;

    // 오디오용
    public AudioClip moving;
    AudioSource audioSource;
    float movingSoundPlayTime;
    float movingSoundDelayTime;
    float attackSoundPlayTime;
    float attackSoundDelayTime;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        movingSoundPlayTime = 2;
        movingSoundDelayTime = 2;
        attackSoundPlayTime = 1;
        attackSoundDelayTime = 1;
        isFast = false;

        timer = 3f;
        Invoke("Think", 3);

    }

    // 패트롤 방향을 3초마다 생각
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Debug.Log("다음 방향은 " + nextMove);

        Invoke("Think", 3);
    }

    void Update()
    {
        target = GetComponentInChildren<RecognitionManager>().target;
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;

        // 추격
        if (isTracing)
        {
            // n초마다 이동사운드 출력
            if (movingSoundPlayTime >= movingSoundDelayTime)
            {
                audioSource.clip = moving;
                audioSource.Play();
                movingSoundPlayTime = 0;
            }
            movingSoundPlayTime += Time.deltaTime;

            speed = 2f;
            Vector3 playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.left;
                direction = "Left";
            }
            else if (playerPos.x > transform.position.x)
            {
                moveVelocity = Vector3.right;
                direction = "Right";
            }
            transform.position += moveVelocity * speed * Time.deltaTime;
        }
        else
        {
            movingSoundPlayTime = 2;

            if (nextMove == -1)
                direction = "Left";
            else if (nextMove == 1)
                direction = "Right";

            Patrol();
            rigid.velocity = new Vector2(nextMove * speed, rigid.velocity.y);
        }

        // 플립
        if (direction == "Left")
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction == "Right")
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    void Patrol()
    {
        // 패트롤
        // 3초마다 1초씩 빠르게 이동
        if (timer <= 0)
        {
            // 도대체 왜 두 개가 같이 나오는데!!!!!!!!!!!!!!!!!!!!!
            if (isFast)
            {
                if (timer > 0)
                {
                    Debug.Log("빠르게!");
                    speed = 4f;
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
                Debug.Log("천천히~");
                speed = 1f;
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    isFast = true;
                    timer = 1f;
                }
            }
        }



        // 추락방지
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.7f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector2.down, 2, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 3 * Time.deltaTime);
        }
    }
    



    // 닿자마자 딜 넣기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 공격사운드 출력
            GetComponentInChildren<SnakeAttackSound>().SAttackSound();
            attackSoundPlayTime = 0;

            target = collision.gameObject;
            GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= GetComponent<MonsterStatusManager>().attack;
            // ********** 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
            Debug.Log("뱀의 공격! 데미지 " + GetComponent<MonsterStatusManager>().attack);
        }

    }

    // 닿아 있으면 1초마다 딜 넣기
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (delaytime > attacktime)
            {
                // n초마다 공격사운드 출력
                if (attackSoundPlayTime >= attackSoundDelayTime)
                {
                    GetComponentInChildren<SnakeAttackSound>().SAttackSound();
                    attackSoundPlayTime = 0;
                }

                GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= GetComponent<MonsterStatusManager>().attack;
                // ********** 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
                Debug.Log("뱀의 공격! 데미지 " + GetComponent<MonsterStatusManager>().attack);

                delaytime = 0;
            }
            attackSoundPlayTime += Time.deltaTime;
            delaytime += Time.deltaTime;
        }
    }
}
