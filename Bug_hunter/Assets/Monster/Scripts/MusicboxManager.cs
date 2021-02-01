using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicboxManager : MonoBehaviour
{
    // 스탯
    public int hp = 40;
    public int attack = 10;
    public int defense = 15;
    int buffRate = 40;

    bool isTracing;                     // 플레이어 인식용
    GameObject player;                  // 그냥 플레이어
    GameObject target;                  // 끌어당길 플레이어
    Rigidbody2D targetrb;
    float targetGravity;
    float targetGravity_original;       // 플레이어의 원래 중력값
    Transform targetTrans;              // 플레이어의 위치
    Transform myPos;                    // 오르골의 위치
    public float forceFactor;           // 당기는 힘값

    float pulltime;
    float cooltime = 1.5f;

    //Animator anim;

    void Start()
    {
        myPos = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        targetGravity_original = player.GetComponent<Rigidbody2D>().gravityScale;
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
    }

    void FixedUpdate()
    {
        if (isTracing && target.gameObject.tag == "Player")
        {
            if(pulltime >= cooltime)
            {
                targetrb.AddForce((myPos.position - targetTrans.position) * forceFactor * Time.fixedDeltaTime);
            }
            pulltime += Time.deltaTime;
        }
    }

}
