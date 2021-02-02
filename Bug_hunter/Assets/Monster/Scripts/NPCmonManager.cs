using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmonManager : MonoBehaviour
{
    // 스탯
    public int hp = 30;
    public int attack = 4;
    int buffRate = 30;

    [SerializeField] float speed = 3.5f;

    public GameObject target;
    [HideInInspector] public bool isDamaged;
    bool isTracing;
    Vector3 moveVelocity = Vector3.zero;
    Vector3 playerPos;

    Animator anim;
    SpriteRenderer spriteRenderer;

    public GameObject bullet;
    [SerializeField] float shoottime = 2;       // 발사시간
    [SerializeField] float cooltime = 2;       // 쿨타임



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isTracing = GetComponentInChildren<NPCRecognition>().isTracing;

        if (isTracing)
        {
            playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerPos.x > transform.position.x)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            transform.position += moveVelocity * speed * Time.deltaTime;

            Attack();
        }
        else if (!isTracing)
        {
            target = null;
            anim.SetBool("Angry", false);
            moveVelocity = Vector3.zero;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "PlayerBullet")
        {
            anim.SetBool("Angry", true);
            isDamaged = true;
            target = GameObject.FindWithTag("Player");
            GetComponentInChildren<NPCRecognition>().isTracing = true;
        }
    }


    void Attack()
    {
        if (shoottime > cooltime)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            Instantiate(bullet, transform.position, Quaternion.AngleAxis(30, Vector3.right));
            Instantiate(bullet, transform.position, Quaternion.AngleAxis(-30, Vector3.right));
            // 아.....xx...........................
            shoottime = 0;
        }
        shoottime += Time.deltaTime;
    }
    void GenerateBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
