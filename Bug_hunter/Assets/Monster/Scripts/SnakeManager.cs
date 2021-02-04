using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    GameObject target;
    bool isTracing;
    string direction = "";
    public float movePower = 1f;
    Vector3 moveVelocity = Vector3.zero;
    float timer = 3f;
    bool isFast;

    float delaytime = 0;
    float attacktime = 1f;

    // 오디오용
    public AudioClip moving;
    public AudioClip attack;
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
        audioSource.volume = 0.3f;

        Invoke("Think", 1);
    }

    void FixedUpdate()
    {

        // 패트롤
        if (!isTracing)
        {
            // 3초에 1초씩 빠르게 이동
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
            // n초마다 이동사운드 출력
            if (movingSoundPlayTime >= movingSoundDelayTime)
            {
                audioSource.Stop();
                audioSource.clip = moving;
                audioSource.Play();
                movingSoundPlayTime = 0;
            }
            movingSoundPlayTime += Time.deltaTime;

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
            movingSoundPlayTime = 2;

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




    // 닿자마자 딜 넣기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 공격사운드 출력
            audioSource.Stop();
            audioSource.clip = attack;
            audioSource.Play();
            attackSoundPlayTime = 0;

            target = collision.gameObject;
            GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= GetComponent<MonsterStatusManager>().attack;
            // ********** 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
            Debug.Log("콰삭!");
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
                    audioSource.Stop();
                    audioSource.volume = 0.3f;
                    audioSource.clip = attack;
                    audioSource.Play();
                    attackSoundPlayTime = 0;
                }

                GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= GetComponent<MonsterStatusManager>().attack;
                // ********** 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
                Debug.Log("콰삭콰삭!");

                delaytime = 0;
            }
            attackSoundPlayTime += Time.deltaTime;
            delaytime += Time.deltaTime;
        }
    }
}
