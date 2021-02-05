using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostManager : MonoBehaviour
{
    float hp;
    bool isDamaged;         // 공격을 받았는가?
    Animator animator;
    public GameObject target;

    int playerHP = 30;           // 플레이어의 HP. 나중에 플레이어와 연결할 것

    // 따라가기용
    // https://youtu.be/jvtFUfJ6CP8
    public AIPath aiPath;
    Transform playerPos;

    // 오디오용
    public AudioClip attack;
    AudioSource audioSource;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        shoottime = 3;
        nextshoot = 3;
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        GetComponentInParent<AIDestinationSetter>().target = playerPos;
        GetComponentInParent<AIDestinationSetter>().enabled = false;
    }

    private void Update()
    {
        hp = GetComponent<MonsterStatusManager>().hp;

        if (isDamaged)
        {
            if (playerHP > 0)
            {
                if (hp > 0)
                {
                    TakeDamage();               // hp가 0 이상이면 추적 시작
                }
                else if (hp <= 0)
                {
                    Death();                    // hp가 0 이하이면 죽음 (애니메이션 재생)
                }
            }
            else if (playerHP <= 0)             // 플레이어가 먼저 죽으면 정지
            {
                Stop();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            isDamaged = true;
        }
    }

    public void TakeDamage()
    {
        // 여기에 피격 사운드 넣기 audio.clip=제목; audio.Play();

        GetComponentInParent<AIDestinationSetter>().enabled = true;
        target = GameObject.FindWithTag("Player");                      // 타깃을 플레이어로 세팅
        animator.SetBool("isAttack", true);
        Attack();
    }

    void Stop()
    {
        GetComponentInParent<AIDestinationSetter>().enabled = false;
        animator.SetBool("isAttack", false);
    }


    void Death()
    {
        GetComponentInParent<AIDestinationSetter>().enabled = false;
        animator.SetBool("isAttack", false);
        animator.SetTrigger("Death");
        //Invoke("DeathAnim", 1);
    }



    [SerializeField] public GameObject bullet;
    float shoottime;
    float nextshoot;

    void Attack()
    {
        Trace();
        if (shoottime >= nextshoot)      // 플레이어가 죽을 때까지 3초마다 한 번씩 탄알 발사
        {
            audioSource.clip = attack;
            audioSource.Play();
            Instantiate(bullet, transform.position, Quaternion.identity);
            shoottime = 0;
        }
        nextshoot = Time.time + shoottime;
    }


    void Trace()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
