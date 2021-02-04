using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxManager : MonoBehaviour
{
    float attack;
    bool isTracing;                     // 플레이어 인식용
    GameObject player;                  // 그냥 플레이어
    GameObject target;                  // 끌어당길 플레이어
    Rigidbody2D targetrb;
    float targetGravity_original;       // 플레이어의 원래 중력값
    Transform targetTrans;              // 플레이어의 위치
    Transform myPos;                    // 오르골의 위치
    public float forceFactor;           // 당기는 힘값

    [SerializeField] float pulltime;
    [SerializeField] float cooltime = 1.5f;
    float playerHP;
    //float playerDef;


    void Start()
    {
        attack = GetComponent<MonsterStatusManager>().attack;
        myPos = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        targetGravity_original = player.GetComponent<Rigidbody2D>().gravityScale;
        // playerDef = player.GetComponent<PlayerStatusManager>().player_Def;  -------------- 추가할것

        pulltime = 1.5f;
    }

    void Update()
    {
        target = GetComponentInChildren<RecognitionManager>().target;
        isTracing = GetComponentInChildren<RecognitionManager>().isTracing;

        if (isTracing && target != null)
        {
            targetrb = target.GetComponent<Rigidbody2D>();
            targetTrans = target.GetComponent<Transform>();
            targetrb.gravityScale = 0.2f;
        }

        if (!isTracing)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = targetGravity_original;
        }

        if (isTracing && target.gameObject.tag == "Player")
        {
            if (pulltime >= cooltime)
            {
                targetrb.AddForce((myPos.position - targetTrans.position) * forceFactor * Time.deltaTime);
                GameObject.Find("Manager").GetComponentInChildren<PlayerStatusManager>().player_HP -= attack;
                // 플레이어 방어력 변수 추가되면 여기에 뭔가 해야함
                Debug.Log("오르골의 공격! 데미지 " + attack);
                pulltime = 0;
            }
            pulltime += Time.deltaTime;
        }
    }
}
