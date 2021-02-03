using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 한 방향으로 탄막 쏘게 하는 방법...
 * 1. Quaternion 각도 조절                  -- 모르겠다
 * 2. Create Empty > BulletPos 1, 2, 3...   -- 비둘기신이 허락안함
 * 3. https://youtu.be/Mq2zYk5tW_E
 */

public class NPCmonManager : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;

    public GameObject target;
    [HideInInspector] public bool isDamaged;
    bool isTracing;
    Vector3 moveVelocity = Vector3.zero;
    Vector3 playerPos;

    Animator anim;
    public float shoottime = 2;                 // 발사시간
    [SerializeField] float cooltime = 2;        // 쿨타임


    bool notEnoughBulletsInPool = true;
    List<GameObject> bullets;
    [SerializeField] int bulletsAmount = 3;
    [SerializeField] float startAngle, endAngle;


    void Start()
    {
        anim = GetComponent<Animator>();
        bullets = new List<GameObject>();
    }

    void Update()
    {
        isTracing = GetComponentInChildren<NPCRecognition>().isTracing;

        if (isTracing)
        {
            playerPos = target.transform.position;

            if (playerPos.x < transform.position.x)
            {
                startAngle = 300; endAngle = 240;
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (playerPos.x > transform.position.x)
            {
                startAngle = 60; endAngle = 120;
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
            shoottime = 2;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerBullet")
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
            float angleStep = (endAngle - startAngle) / bulletsAmount;
            float angle = startAngle;

            for (int i = 0; i < bulletsAmount; i++)
            {
                float bulDirX = transform.GetComponent<Transform>().position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.GetComponent<Transform>().position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

                Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
                Vector2 bulDir = (bulMoveVector - transform.position).normalized;

                GameObject bul = NPCBulletPool.bullePoolInstanse.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<NPCBulletManager>().SetMoveDirection(bulDir);

                angle += angleStep;
            }

            shoottime = 0;
        }
        shoottime += Time.deltaTime;
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                    return bullets[i];
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(GetComponentInChildren<NPCBulletPool>().Bullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }

}
