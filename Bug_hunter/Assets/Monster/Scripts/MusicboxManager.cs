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
        myPos = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        targetGravity_original = player.GetComponent<Rigidbody2D>().gravityScale;
        playerHP = player.GetComponent<PlayerStatusManager>().player_HP;
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
                playerHP -= attack;
                Debug.Log("빡! 플레이어 HP: " + playerHP + ", 데미지 " + attack);
                pulltime = 0;
            }
            pulltime += Time.deltaTime;
        }
    }




    SpriteRenderer spriteRenderer;
    new CapsuleCollider2D collider;

    // 체력 0 이하일 때 피격효과 내고 사라진다.
    public void OnDamaged(int damage)
    {
        if (hp <= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);        // 맞으면 반투명해짐
            collider.enabled = false;                               // 충돌 끄기
            Invoke("Destroy", 1.5f);                                // 1.5초 뒤 사라짐
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
