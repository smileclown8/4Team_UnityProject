using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxManager : MonoBehaviour
{
    float damage;
    bool isTracing;                     // 플레이어 인식용
    GameObject player;                  // 그냥 플레이어
    GameObject target;                  // 끌어당길 플레이어
    Rigidbody2D targetrb;
    float targetGravity_original;       // 플레이어의 원래 중력값
    bool isGravityChange;
    Transform targetTrans;              // 플레이어의 위치
    Transform myPos;                    // 오르골의 위치
    public float forceFactor = 1500;    // 당기는 힘값

    [SerializeField] float pulltime;
    [SerializeField] float cooltime = 1.5f;

    // 오디오용
    AudioSource audioSource;
    public AudioClip idleSound;


    void Awake()
    {
        myPos = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        damage = GetComponent<MonsterStatusManager>().attack;

        targetGravity_original = player.GetComponent<Rigidbody2D>().gravityScale;
        // playerDef = player.GetComponent<PlayerStatusManager>().player_Def;  -------------- 추가할것

        pulltime = 1.5f;

        audioSource.volume = 0;
        audioSource.clip = idleSound;
        audioSource.Play();
    }


    void FixedUpdate()
    {
        target = GetComponentInChildren<RecognitionManager>().target;
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;

        // 무언가가 인식범위에 들어왔으면 들어온 플레이어의 Rigidbody, Transform, gravity를 가져온다.
        if (isTracing && target != null)
        {
            isGravityChange = false;

            targetrb = target.GetComponent<Rigidbody2D>();
            targetTrans = target.GetComponent<Transform>();
            targetrb.gravityScale = 0.2f;   // 끌어당기기 위해 플레이어의 중력값을 0.2로 설정
        }

        // 아무것도 인식중이지 않으면 소리 재생을 멈추고, 플레이어의 중력을 원래대로 되돌린다.
        if (!isTracing)
        {
            audioSource.volume = 0;

            // 1회 되돌리고 그대로 놔둔다.
            if(isGravityChange == false)
            {
                player.GetComponent<Rigidbody2D>().gravityScale = targetGravity_original;
                isGravityChange = true;
            }
        }

        // 플레이어가 인식범위에 들어오면 오르골 소리를 재생하고 일정 시간마다 플레이어를 끌어당긴다.
        if (isTracing && target.gameObject.tag == "Player")
        {
            // 오르골 소리 재생
            audioSource.volume = 1;

            if (pulltime >= cooltime)
            {
                GetComponentInChildren<MusicboxAttackSound>().MBAttackSound();
                targetrb.AddForce((myPos.position - targetTrans.position) * forceFactor * Time.deltaTime);
                GameObject.Find("PlayerStatusManager").GetComponentInChildren<PlayerStatusManager>().player_HP -= damage;
                // 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
                Debug.Log("오르골의 공격! 데미지 " + damage);
                pulltime = 0;
            }
            pulltime += Time.deltaTime;
        }
    }

    // 맞았을 때의 데미지 계산은 몬스터 스테이터스 매니저가...
}
